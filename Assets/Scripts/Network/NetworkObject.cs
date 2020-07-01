using UnityEngine;
using System;

public class NetworkObject
{
    public string ObjectName;// { get; set; }
    public string Object;// { get; set; }

    public NetworkObject(string json)
    {
        try
        {
            JsonUtility.FromJsonOverwrite(json, this);
        } catch (Exception e)
        {
            Debug.LogError("Cannot construck NetworkObject: " + e);
            throw new Exception("Cannot construct NetworkObject");
        }
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
            Debug.LogError("Cannot convert Object to " + ObjectName + " with exception: " + e.Message);
            throw new Exception("Cannot convert Object to " + ObjectName + " with exception: " + e.Message);
        }
    }
}
