import json

# db_name
# db_username
# db_password

with open('config.json', 'r') as f:
    config = json.loads(f.read())

if not "server_name" in config: config["server_name"] = "Kltn-Auth server"
if not "server_info" in config: config["server_info"] = "Welcome to use Kltn-Auth!"
