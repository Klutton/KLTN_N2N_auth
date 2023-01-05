import os
import json
import uuid
import redis
from flask import Flask, request, make_response, session, redirect
from flask_login import LoginManager

invite_code_list: list = []

# redis config
pool = redis.ConnectionPool(host='127.0.0.1')
_redis = redis.Redis(connection_pool=pool)

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


"""@login_manager.user_loader()
def load_user(user_id):
    if user_id == 'asd':
        return User.get(user_id)
"""


@app.before_request
def identify():
    resp = make_response(redirect(request.path))
    if not request.cookies or session:
        session['id'] = str(uuid.uuid4())
        if not session['user']:
            session['user'] = None
        return resp
    else:
        pass


@app.route("/n2n_login", methods=['POST'])
def login():



@app.route("/n2n_register", methods=['GET', 'POST'])
def register():
    if request.method == 'POST':
        if identify_code(request.form['code']):
            create
        else:
            return "invalid invite_code!"


@app.route("/n2n_getcode", methods=["POST"])
def get_code():
    if session['username'] is None:
        return 'Please Login'
    elif session['auth'] == 'admin':
        return new_code()
    else:
        return 'flag{G1ve_u_f3ke_fL4g}'


@app.route("/test")
def test():
    return str(session.get('id'))


if __name__ == '__main__':
    app.run()
    # login_manager.init_app(app)
