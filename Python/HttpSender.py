import requests

url = 'http://localhost:4444'
myobj = {'somekey': 'somevalue'}

x = requests.post(url, data = myobj)

print(x.text)