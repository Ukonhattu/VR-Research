using System.Collections.Generic;
using System;
using System.Linq;

public sealed class Observer
{
    private Dictionary<Type, List<Listener<EventData>>> listeners;

    public static Observer Instance { get; } = new Observer();

    public void Subscribe(Listener<EventData> listener)
    {
        List<Listener<EventData>> list;
        if (listeners.ContainsKey(listener.GetType().GetGenericArguments().Single()))
        {
            listeners.TryGetValue(listener.GetType().GetGenericArguments().Single(), out list);
        } else
        {
            list = new List<Listener<EventData>>();
        }
        list.Add(listener);
        listeners.Add(listener.GetType().GetGenericArguments().Single(), list);
    }

    public void Publish(EventData data)
    {
        List<Listener<EventData>> listenerList;
        this.listeners.TryGetValue(data.GetType(), out listenerList);
        foreach (Listener<EventData> listener in listenerList)
        {
            listener.Listen(data);
        }
    }

    private Observer()
    {
        this.listeners = new Dictionary<Type, List<Listener<EventData>>>();
    }

}
