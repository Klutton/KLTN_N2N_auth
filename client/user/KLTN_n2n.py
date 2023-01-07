import ctypes
import json
import os
import random
import subprocess
import sys

import requests


def is_admin():
    try:
        return ctypes.windll.shell32.IsUserAnAdmin()
    except:
        return False


if not is_admin():
    ctypes.windll.shell32.ShellExecuteW(None, "runas", sys.executable, __file__, None, 1)
    exit()


def randkey(l: int = 8):
    r = ''
    liss: str = '0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM'
    le = len(liss) - 1
    for i in range(l):
        r += liss[random.randint(0, le)]
    return r


def connect(s: dict, ser: str):
    try:
        r = requests.post(ser + ':5000/n2n_connect', data=s, timeout=5)
        if r.status_code == 200:
            return r.json()
        else:
            return -1
    except Exception as e:
        print(f'连接到服务器失败：{e}')
        return -1


key = 'QSD>ak)as[d6a5d4AFfm.+faSD51'

with open('config.json', 'r') as f:
    config: dict = json.loads(f.read())

if config['username'] == '':
    config['username'] = str(input("您的配置文件中账号为空，请输入你的账号："))
    config['password'] = str(input('密码：'))


def check():
    try:
        if len(config['group']) == 8 and config['group'].isalnum:
            return True
        else:
            return False
    except:
        return False


'''while not check():
    config['group'] = str(input("您的配置文件中群组不为八位字母，请输入八位群组："))'''

username = config['username']
password = config['password']
server = 'http://' + config['server']
orserver = config['server']
group = 'NETWORKS'  # config['group']
print(f'正在尝试连接到主服务器：{server}\n'
      f'账号：{username}\n'
      f'密码：{password}\n'  # f'群组：{group}\n'
      )
if group != "NETWORKS":
    print('默认群组为：NETWORKS，推荐使用相同群组，有机会找到更多同伴')
s = {'username': username, 'password': password, 'key': 'QSD>ak)as[d6a5d4AFfm.+faSD51'}
res = connect(s, server)
for i in range(1, 6):
    if res != -1:
        break
    print(f"正在重试。。。{i}/5")
    res = connect(s, server)
if res == -1:
    print(f"连接失败，请检查您的账号密码，可以尝试\n1.前往'{server}:5000/'验证账号密码是否正确"
          f"\n2.检查服务器地址是否正确"
          f"\n3.联系管理员")
    os.system('pause')
else:
    print("连接成功，正在启动n2n edge, 按ctrl+c停止程序")
    try:
        if not 'edge.exe' in os.listdir():
            print("\n启动失败，请检查edge.exe是否在此文件夹内")
            os.system('pause')

        subprocess.run([f'.\edge.exe', '-c', group, '-l', f'{orserver}:{res["port"]}'
                           , '-k', randkey()], shell=True, stdout=1)
    except:
        exit()
