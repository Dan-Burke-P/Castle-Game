using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName="Event System/Base Event")]
public class Event : ScriptableObject
{
    public string eventName = "Base Event";

    [SerializeField]
    private List<EventListener> _listeners;

    public Dictionary<string, object> data;

    public void raise(Dictionary<string, object> d)
    {
        data = d;
        foreach (EventListener el in _listeners)
        {
            
        }
    }

    public void register(EventListener el)
    {
        _listeners.Add(el);
    }

    public void deregister(EventListener el)
    {
        _listeners.Remove(el);
    }

}
