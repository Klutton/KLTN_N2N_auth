import json

config = {}

with open('./config.json', 'r') as f:
    config = json.loads(f)