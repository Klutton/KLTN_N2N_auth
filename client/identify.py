import base64

import Crypto.PublicKey
from Crypto.Cipher import PKCS1_v1_5 as PKCS1_cipher
from Crypto.PublicKey import RSA

en_msg = str(input('msg:'))

with open('../tools/pri_key.pem', 'r') as f:
    key = RSA.importKey(f.read())
    cipher = PKCS1_cipher.new(key)
    decrypt_data = cipher.decrypt(base64.b64decode(en_msg), 0)
    print(decrypt_data.decode("utf-8"))