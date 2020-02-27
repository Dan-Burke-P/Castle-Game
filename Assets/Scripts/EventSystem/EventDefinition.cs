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
