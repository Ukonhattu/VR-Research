using UnityEngine;
using System;

public class NetworkObject
{
    public string ObjectName { get; set; }
    public string Object { get; set; }

    // Should this be illegal?
    public NetworkObject(string json)
    {
        NetworkObject newObject = JsonUtility.FromJson<NetworkObject>(json);
        this.ObjectName = newObject.ObjectName;
        this.Object = newObject.Object;
    }

    public NetworkObject()
    {
        this.ObjectName = null;
        this.Object = null;
    }

    public NetworkObject(string objectName, string objectjson)
    {
        this.ObjectName = ObjectName;
        this.ObjectName = objectjson;
    }

    public object GetObject()
    {
        try
        {
            Type type = Type.GetType(ObjectName);
            return JsonUtility.FromJson(this.Object, type);
        }
        catch (Exception e)
        {
            throw new Exception("Cannot convert Object to " + ObjectName + " with exception: " + e.Message);
        }
    }
}
