using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public sealed class Observer
{
    private Dictionary<Type, List<Listener<EventData>>> listeners;

    public static Observer Instance { get; } = new Observer();

    public void Subscribe<T>(Listener<T> listener)
    {
        List<Listener<EventData>> list;
        if (listeners.ContainsKey(listener.GetType().GetGenericArguments().Single()))
        {
            listeners.TryGetValue(listener.GetType().GetGenericArguments().Single(), out list);
        } else
        {
            list = new List<Listener<EventData>>();
        }
        if (listener.GetType().Equals(typeof(Listener<EventData>)))
        {
            list.Add(listener as Listener<EventData>);
        } else
        {
            Debug.LogError("Listener is not of valid type");
            throw new Exception("Listener is not of valid type");
        }
        listeners.Add(listener.GetType().GetGenericArguments().Single(), list);
    }

    public void Publish(EventData data)
    {
        Debug.Log("Making the list");
        List<Listener<EventData>> listenerList;
        Debug.Log("Trying to get value");
        bool isListening = this.listeners.TryGetValue(data.GetType(), out listenerList);
        if (!isListening)
        {
            Debug.Log("No one is lsitening");
            return;
        }
        Debug.Log("Got Value: " + listenerList.ToString());
        foreach (Listener<EventData> listener in listenerList)
        {
            listener.Listen(data);
        }
        Debug.Log("Looped trough all relevant listeners");
    }

    private Observer()
    {
        this.listeners = new Dictionary<Type, List<Listener<EventData>>>();
    }

}
