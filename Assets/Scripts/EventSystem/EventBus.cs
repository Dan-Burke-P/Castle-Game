using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventBus
{
    // Make sure we private the constructor to avoid other instances being made errantly 
    private EventBus(){
    }

    // Use singleton design so we can centralize how we register events to a single back bone component
    private static EventBus _instance;

    public static EventBus Instance(){
        if (_instance == null){
            _instance = new EventBus();
            return _instance;
        }
        else{
            return _instance;
        }
    }

    public Dictionary<string ,RegisteredEvent> registeredEvents = new Dictionary<string, RegisteredEvent>();

    public bool checkEventExists(string ename){
        return registeredEvents.ContainsKey(ename);
    }

    public RegisteredEvent findRegisteredEvent(string eventName){
        RegisteredEvent re;
        if (registeredEvents.TryGetValue(eventName, out re)){
            return re;
        }

        return new RegisteredEvent("INVALID-EVENT");
    }
    
    
    
    public int RegisterEvent(EventDefinition ed){
        RegisteredEvent re = findRegisteredEvent(ed.eventName);

        if (re.eventName.Equals("INVALID-EVENT")){
            return -1;
        }

        re.registerTarget(ed.eventTarget, ed.action);
        
        
        
        return 0;
    }

    public int CreateNewEventType(string eventName){

        if (!checkEventExists(eventName)){
            // If the event does not exist we can create a new event
            RegisteredEvent re = new RegisteredEvent(eventName);
            registeredEvents.Add(eventName, re);
            return 1;
        }
        else{
            Debug.LogError("Event already exists!");
            return -1;
        }
    }

    public int raiseEvent(EventDefinition ed, Dictionary<string, object> prm){
        
        // Try to find the registered event
        RegisteredEvent re = findRegisteredEvent(ed.eventName);
        
        if (re.eventName.Equals("INVALID-EVENT")){
            // If we get an invalid event back just exit badly
            Debug.LogError($"Event: {ed.eventName} Targeting: {ed.eventTarget} Failed to find event");
            return -1;
        }
        re.RaiseTarget(ed.eventTarget, prm);

        return 0;
    }
}