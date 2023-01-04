from Crypto.PublicKey import RSA

key = RSA.generate(2048)

pri_key = key.export_key()
with open("./pri_key.pem", "wb") as f:
    f.write(pri_key)

pub_key = key.public_key().export_key()
with open("./pub_key.pem", "wb") as f:
    f.write(pub_key)

print('key generate complete')