import os
import json
import uuid

from flask import Flask, request, make_response, session, redirect
from flask_login import LoginManager

pending_invite_code = str(uuid.uuid4()).replace('-', '')
print(pending_invite_code)
invite_code_list: list = []

app = Flask(__name__)
app.secret_key = os.urandom(24)
login_manager = LoginManager()


def new_code():
    global pending_invite_code
    pending_invite_code = pending_invite_code = str(uuid.uuid4()).replace('-', '')
    return


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
        resp.set_cookie("name", "python")
        return resp
    else:
        pass


@app.route("/n2n_login", methods=['POST'])
def login():

    return f"{request.form['username'], request.form['password']}"


@app.route("/n2n_register", methods=['POST'])
def register():
    if not request.form['code'] in app.secret_key:
        return json.dump({'status': 'wrong_code'})


@app.route("/n2n_getcode", methods=["POST"])
def get_code():
    # if request.form['token'] ==
    return 'not yet'


@app.route("/test")
def test():
    return str(session.get('id'))


if __name__ == '__main__':
    app.run()
    # login_manager.init_app(app)
