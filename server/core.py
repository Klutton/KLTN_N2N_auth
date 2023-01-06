import os
import settings
import json
import uuid
import redis
import psycopg2
from flask import Flask, request, make_response, session, redirect
from flask_login import LoginManager

invite_code_list: list = []

# redis config
try:
    pool = redis.ConnectionPool(host='127.0.0.1')
    _redis = redis.Redis(connection_pool=pool)
except Exception as e:
    print(f"连接到redis失败，报错：{e}")

# postgreSQL config
try:
    db = psycopg2.connect(database=settings.config['dbname'], user=settings.config['db_username'],
                          password=settings.config['db_password'])
    cur = db.cursor()
except Exception as e:
    print(f"疑似配置文件有误，或连接数据库失败，报错：{e}")

# flask config
app = Flask(__name__)
app.secret_key = os.urandom(24)
login_manager = LoginManager()


def new_code(seconds: int = 60 * 60 * 72):  # 默认有效时间为72小时
    pending_invite_code = str(uuid.uuid4()).replace('-', '')
    _redis.set(name=pending_invite_code, value='value_is_meaningless', ex=seconds)
    return pending_invite_code


def identify_code(code: str):
    return True if _redis.exists(code) else False


def auth(username: str):
    cur.execute(f"SELECT {username} FROM users;")
    res = cur.fetchone()
    return res[4]


def check_format(form: dict):
    if form['username'].isalnum() and type(form['username']) == str and form['password'].isalnum() and type(
            form['password']) == str \
            and len(form['username']) < 20 and len(form['password']) < 20:
        return True
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
        return resp
    else:
        pass


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
                cur.execute(f'SELECT {request.form["username"]} ')


@app.route("/n2n_register", methods=['GET', 'POST'])
def register():
    if request.method == 'POST':
        if check_format(request.form):
            if not 'code' in request.form: return "邀请码有误"
            if identify_code(request.form['code']):
                return "code"
            return "邀请码有误"
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
            	<input type="submit" name="" class="but" value="登录" />
            </form>"""


@app.route("/n2n_getcode", methods=["GET"])
def get_code():
    if not 'username' in session:
        return 'Please Login'
    if auth(session['username']) == 1:
        return new_code()
    else:
        return 'flag{G1ve_u_f3ke_fL4g}'


@app.route("/test")
def test():
    return str(session.get('id'))


if __name__ == '__main__':
    app.run()
    # login_manager.init_app(app)
