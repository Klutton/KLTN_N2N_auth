import os
import time
import uuid

import bcrypt
import psycopg2
import redis
from flask import Flask, request, make_response, session, redirect, jsonify
from flask_login import LoginManager

import settings

# redis config
try:
    pool = redis.ConnectionPool(host='127.0.0.1')
    _redis = redis.Redis(connection_pool=pool)
except Exception as e:
    print(f"连接到redis失败，报错：{e}")

# postgreSQL config
try:
    db = psycopg2.connect(database=settings.config['db_name'], user=settings.config['db_username'],
                          password=settings.config['db_password'])
    cur = db.cursor()
except Exception as e:
    print(f"疑似配置文件有误，或连接数据库失败，报错：{e}")

# flask config
app = Flask(__name__)
app.secret_key = os.urandom(24)
login_manager = LoginManager()


def new_code(seconds: int = 60 * 60 * 72, expire: int = 60 * 60 * 24 * 30):  # 默认有效时间为72小时
    pending_invite_code = str(uuid.uuid4()).replace('-', '')
    _redis.set(name=pending_invite_code, value=expire, ex=seconds)
    return pending_invite_code, expire


def identify_code(code: str):
    return True if _redis.exists(code) else False


def auth(username: str):
    cur.execute(f"SELECT auth FROM users WHERE username='{username}';")
    res = cur.fetchone()[0]
    return res


def check_format(form):
    try:
        if form['username'].isalnum() and type(form['username']) == str and form['password'].isalnum() and type(
                form['password']) == str \
                and len(form['username']) < 20 and len(form['password']) < 20:
            return True
        return False
    except:
        return False


def check_login(u: str, p: str):
    cur.execute(f"SELECT password FROM users WHERE username='{u}';")
    hashed = cur.fetchone()[0]
    if bcrypt.checkpw(p.encode(), hashed.encode()):
        return True
    else:
        return False


'''def auth(name: str):
    if cur.execute()'''

"""@login_manager.user_loader()
def load_user(user_id):
    if user_id == 'asd':
        return User.get(user_id)
"""


@app.before_request
def identify():
    resp = make_response(redirect(request.path))
    if not session:
        session['id'] = str(uuid.uuid4())
        pass
    else:
        pass


@app.route('/')
def index():
    res = '''<h1>KLTN_N2N_auth 1.0<h1>
        <p><a href=/n2n_login>登录<a>
        <p><a href=/n2n_register>注册<a>
        <p><a href=/n2n_profile>个人信息<a>'''
    if 'username' in session:
        if auth(session['username']) == 1:
            res += '''<p><a href=/n2n_getcode>获取验证码<a>'''
    return res


@app.route("/n2n_login", methods=['GET', 'POST'])
def login():
    if request.method == 'GET':
        return """
        <a href=/>返回首页<a>
        </form>
            <form action="" method="post">
            	<h1>登录</h1>
            	<input type="text" placeholder="用户名" name="username">
            	<input type="password" placeholder="密码" name="password">
            	<input type="submit" name="" class="but" value="登录" />
            </form>"""

    if request.method == 'POST':
        if 'username' and 'password' in request.form and session['id']:
            if check_format(request.form):
                try:
                    username = request.form['username']
                    password = request.form['password']
                    if check_login(username, password):
                        session['username'] = username
                        return f'欢迎，{username}<p><a href=/>返回<a>'
                    else:
                        return '账号密码错误<p><a href="/n2n_login">返回<a>'
                except:
                    return '账号密码错误<p><a href="/n2n_login">返回<a>'
    return f'请求有误<p><a href="{request.path}">返回<a>'


@app.route("/n2n_register", methods=['GET', 'POST'])
def register():
    if request.method == 'POST':
        if check_format(request.form):
            if not 'code' in request.form: return '''邀请码有误<a href="/n2n_register">返回<a>'''

            code = request.form['code']
            if identify_code(code):
                username = request.form['username']
                cur.execute(f"SELECT username FROM users WHERE username='{username}'")
                if not cur.fetchone() is None:
                    return '''账号已存在<a href="/n2n_register">返回<a>'''
                password = request.form['password']
                now = time.time()
                exp = now + int(_redis.get(code))
                rnow = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(now))
                rexp = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(exp))
                auth = 0

                salt = bcrypt.gensalt(rounds=10)
                hashed = bcrypt.hashpw(password.encode(), salt).decode()

                cur.execute(f"INSERT INTO users VALUES ('{username}', '{hashed}', '{rnow}'"
                            f", '{rexp}', {auth});")
                db.commit()
                _redis.delete(code)
                strtime = time.strftime('%Y年%m月%d日 %H:%M:%S', time.localtime(exp))
                return f'''<h3>注册成功<h3>
                <p>您的用户名{username}<p>
                <p>有效期至{strtime}
                <p><a href=/>返回<a>
                '''

            return '''邀请码有误<a href="/n2n_register">返回<a>'''
            # create
        else:
            return '''<p>仅支持20位以下数字字母组成的密码<p>
                      <a href="/n2n_register">返回<a>'''

    if request.method == 'GET':
        return """
        <a href=/>返回首页<a>
        </form>
            <form action="" method="post">
            	<h1>注册账号</h1>
            	<p>请注意，对账号、密码最短长度没设限制，请自行斟酌，避免密码强度过低被盗！<p>
            	<input type="text" placeholder="用户名" name="username">
            	<input type="password" placeholder="密码" name="password">
            	<input type="text" placeholder="邀请码" name="code">
            	<input type="submit" name="" class="but" value="注册" />
            </form>"""

    return f'请求有误<p><a href="{request.path}">返回<a>'


@app.route('/n2n_connect', methods=['POST'])
def connect():
    if request.method == 'POST':
        if check_format(request.form):
            if check_login(request.form['username'], request.form['password']):
                if request.form['key'] == settings.config['key']:
                    return jsonify({"port": settings.config['port']})

    else:
        return '404'


@app.route('/n2n_profile')
def profile():
    if not 'username' in session:
        return '未登录<a href=/>返回<a>'
    else:
        username = session['username']
        cur.execute(f"SELECT reg_date,exp_date FROM users WHERE username = '{username}';")
        res = cur.fetchone()
        reg, expt = res[0], res[1]
        return f'用户名：{username}<p>注册时间：{reg}<p>账号失效时间：{expt}<p><p><a href=/>返回<a>'


@app.route("/n2n_getcode", methods=["GET"])
def get_code():
    if not 'username' in session:
        return 'Please Login'
    if auth(session['username']) == 1:
        code, exp = new_code()
        expt = time.strftime('%Y年%m月%d日 %H:%M:%S', time.localtime(time.time() + exp))
        return f'''失效时间：{expt}<p>邀请码：<p>{code}'''
    else:
        return '带嗨阔摇了我吧呜呜呜<p>flag{G1ve_u_f3ke_fL4g}'


if __name__ == '__main__':
    app.run(host='0.0.0.0')
    # login_manager.init_app(app)
