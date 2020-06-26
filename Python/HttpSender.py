import requests
import sys
import getopt


def main(argv):

    objectName = "SomeName"
    imagePath = "Some//Path//"
    viewSeconds = 4.0
    oid = 1

    try:
        opts, args = getopt.getopt(argv,"ho:p:v:i:",["objectName=","imagePath=", "viewSeconds=", "id="])
    except getopt.GetoptError:
        print ('HttpSender.py -o <objectName> -p <imagePath> -v <viewSeconds> -i <id>')
        sys.exit(2)
    for opt, arg in opts:
        if opt == '-h':
            print ('HttpSender.py -o <objectName> -p <imagePath> -v <viewSeconds> -i <id>')
            sys.exit()
        elif opt in ("-o", "--objectName"):
            objectName = arg
        elif opt in ("-p", "--imagePath"):
            imagePath = arg
        elif opt in ("-v", "--viewSeconds"):
            viewSeconds = arg
        elif opt in ("-i", "--id"):
            oid = arg
    
    url = 'http://localhost:4444'
    data = '{{ "ObjectName": "{0}", "Object": "{{ "ImagePath": "{1}", "ViewSeconds": {2}, "Id": {3} }}" }}'.format(objectName, imagePath, viewSeconds, oid)
    print(data)
    x = requests.post(url, data = data)

    print(x.text)

if __name__ == "__main__":
    main(sys.argv[1:])
