import json

# db_name
# db_username
# db_password

with open('config.json', 'r') as f:
    config = json.loads(f.read())