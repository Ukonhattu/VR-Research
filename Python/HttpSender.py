import requests

url = 'http://localhost:4444'
myobj = {'ImagePath': 'somevalue', "ViewSeconds": 4.0, "Id": 1}

x = requests.post(url, data = myobj)

print(x.text)