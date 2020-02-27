using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Defines an actual event
public class EventDefinition
{
    public UnityAction<Dictionary<string, object>> action;
    
    public string eventName;
    public string eventTarget;
    public double ID;
    public List<string> paramList;
}

// Holds all events registered to a given name
public class RegisteredEvent
{
    // Constructor
    public RegisteredEvent(string en){
        eventName = en;
    }
    
    public string eventName {get;}
    
    private Dictionary<string, EventTargets> subTargets = new Dictionary<string, EventTargets>();

    public int registerTarget(string targetName, UnityAction<Dictionary<string, object>> action){

        EventTargets et;
        Debug.Log($"Event {eventName} is having {targetName} attempting to register as a target");
        if (subTargets.TryGetValue(targetName, out et)){
            // We succeeded in finding the event target specified 
            et.addCallback(action);
            return 0;
        }
        else{
            // We didn't find the target so make a new one and register it to this event
            et = new EventTargets();
            et.targetName = targetName;
            et.addCallback(action);
            
            subTargets.Add(targetName, et);
            return 1;
        }
    }

    public int RaiseTarget(string trg, Dictionary<string, object> prms){
        
        EventTargets et;
        if (subTargets.TryGetValue(trg, out et)){
            // We succeeded in finding the event target specified
            Debug.Log($"Raising Target: {trg}"); 
            et.invoke(prms);
            return 0;
        }
        Debug.Log($"Failed to find Target: {trg} in Event: {eventName}");

        return -1; 
    }
    
}

// An event target for being specific in a registered event
public class EventTargets
{
    public string targetName;

    private UnityAction<Dictionary<string, object>> callStack;

    public void addCallback(UnityAction<Dictionary<string, object>> ua){
        Debug.Log($"{targetName} is registering a new event callback");
        callStack += ua;
    }

    public void invoke(Dictionary<string, object> prms){
        Debug.Log($"Invoking action for target: {targetName}");
        callStack(prms);
    }
}

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
        Debug.Log("Registering event: " + ed.eventName);
        RegisteredEvent re = findRegisteredEvent(ed.eventName);

        if (re.eventName.Equals("INVALID-EVENT")){
            return -1;
        }

        re.registerTarget(ed.eventTarget, ed.action);
        
        
        
        return 0;
    }

    public int CreateNewEventType(string eventName){

        Debug.Log("Creating new event type: " + eventName);

        if (!checkEventExists(eventName)){
            // If the event does not exist we can create a new event
            RegisteredEvent re = new RegisteredEvent(eventName);
            registeredEvents.Add(eventName, re);
            return 1;
        }
        else{
            Debug.Log("Event already exists!");
            return -1;
        }
    }

    public int raiseEvent(EventDefinition ed, Dictionary<string, object> prm){
        
        // Try to find the registered event
        RegisteredEvent re = findRegisteredEvent(ed.eventName);
        
        if (re.eventName.Equals("INVALID-EVENT")){
            // If we get an invalid event back just exit badly
            Debug.Log($"Event: {ed.eventName} Targeting: {ed.eventTarget} Failed to find event");
            return -1;
        }

        Debug.Log($"Event: {ed.eventName} Targeting: {ed.eventTarget} found event and is raising target");
        re.RaiseTarget(ed.eventTarget, prm);

        return 0;
    }
}