using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    // This is the function that will be invoked when this listener is called
    public UnityEvent ue;
    public UnityAction<Dictionary<string, object>> ua;
    
    public Event _event;
    public bool handled;
    
    public Dictionary<string, object> data;
    
    void Start()
    {
        _event.register(this);
        //Debug.Log("Registering EL");
    }

    public void registerAction(UnityAction<Dictionary<string, object>> action)
    {
        Debug.Log("Registering new action to listener");
        ua += action;
    }
    
    public void onEvent(Dictionary<string, object> d)
    {
        ue.Invoke();
        ua.Invoke(d);
    }

    private void OnDisable()
    {
        _event.deregister(this);
    }
}
