import uuid


def create(num: int):
    l = {}
    for i in range(0, num):
        l[str(uuid.uuid4()).replace('-', '')] = str(uuid.uuid4()).replace('-', '')

    return l





if __name__ == '__main__':
    print(create(300))
