using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



// An event target for being specific in a registered event
public class EventTargets
{
    public string targetName;

    private UnityAction<Dictionary<string, object>> callStack;

    public void addCallback(UnityAction<Dictionary<string, object>> ua){
        callStack += ua;
    }

    public void invoke(Dictionary<string, object> prms){
        callStack(prms);
    }
}