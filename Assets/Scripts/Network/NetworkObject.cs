using UnityEngine;
using System;

public class NetworkObject
{
    public string ObjectName;// { get; set; }
    public string Object;// { get; set; }

    public NetworkObject(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public object GetObject()
    {
        try
        {
            Type type = Type.GetType(this.ObjectName);
            return JsonUtility.FromJson(this.Object, type);
        }
        catch (Exception e)
        {
            throw new Exception("Cannot convert Object to " + ObjectName + " with exception: " + e.Message);
        }
    }
}
