using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    // This is the function that will be invoked when this listener is called
    public UnityEvent ue;
    public Event _event;

    void Start()
    {
        _event.register(this);
        Debug.Log("Registering EL");
    }
    
    public void onEvent()
    {
        ue.Invoke();
    }

    private void OnDisable()
    {
        _event.deregister(this);
    }
}
