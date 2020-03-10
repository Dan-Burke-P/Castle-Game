using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Defines an actual event
public class EventDefinition
{

    public EventDefinition(){
        
    }

    /// <summary>
    /// Used for constructing an event definition with passed parameters
    /// </summary>
    /// <param name="EN">
    /// The event name
    /// </param>
    /// <param name="ET">
    /// The target inside the event name
    /// </param>
    /// <param name="ID">
    /// The ID pass through
    /// </param>
    public EventDefinition(string EN, string ET, double ID){
        eventName = EN;
        eventTarget = ET;
        ID = ID;
    }
    
    /// <summary>
    /// Used for constructing an event definition with passed parameters
    /// </summary>
    /// <param name="EN">
    /// The event name
    /// </param>
    /// <param name="ET">
    /// The target inside the event name
    /// </param>
    /// <param name="ID">
    /// The ID pass through
    /// </param>
    /// <param name="act">
    /// The action we want to link to the event
    /// </param>
    public EventDefinition(string EN, string ET, double ID, UnityAction<Dictionary<string,object>> act){
        eventName = EN;
        eventTarget = ET;
        ID = ID;
        action = act;
    }
    
    
    public string eventName;
    public string eventTarget;
    public double ID;
    
    // TODO factor this out so instead of storing the params in here they are passed into
    // Their subsequent function calls
    public List<string> paramList;
    public UnityAction<Dictionary<string, object>> action;
}
