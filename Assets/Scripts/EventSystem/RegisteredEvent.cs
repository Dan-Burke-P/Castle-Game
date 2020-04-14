using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


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

        Debug.Log("Adding target to action");
        EventTargets et;
        if (subTargets.TryGetValue(targetName, out et)){
            // We succeeded in finding the event target specified 
            et.addCallback(action);
            return 0;
        }
        else{
            // We didn't find the target so make a new one and register it to this event
            Debug.Log("Didn't find target so adding new target");
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
            et.invoke(prms);
            return 0;
        }
        Debug.LogError($"Failed to find Target: {trg} in Event: {eventName}");

        return -1; 
    }
    
}
