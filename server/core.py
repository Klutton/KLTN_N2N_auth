import os
import json
import uuid
from flask import Flask, request

pending_invite_code = str(uuid.uuid4()).replace('-', '')
print(pending_invite_code)
invite_code_list: list = []

app = Flask(__name__)
app.secret_key = os.urandom(24)


def new_code():
    global pending_invite_code
    pending_invite_code = pending_invite_code = str(uuid.uuid4()).replace('-', '')
    return


@app.before_request
def identify():



@app.route("/n2n_login", methods=['POST'])
def login():
    return f"{request.form['username'], request.form['password']}"


@app.route("/n2n_register", methods=['POST'])
def register():
    if request.form['code'] != app.secret_key:
        return json.dump({'status': 'wrong_code'})


if __name__ == '__main__':
    app.run(debug=True)
