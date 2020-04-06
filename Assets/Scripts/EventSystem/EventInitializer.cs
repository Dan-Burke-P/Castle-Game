using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public static class EventInitializer
{
    // Add event names here they will all be initialized when game master awakes
    private static readonly string[] _eventNames =
    {
        "AddUnitToBoard",
        "SelectUnit",
        "RemoveUnitFromBoard",
        "MoveUnit",
        "AddCardToHand"
    };

    public static void initEvents(){
        foreach (string s in _eventNames){
            EventBus.Instance().CreateNewEventType(s);
        }
        
        EventBus.Instance().printEventList();
        EventBus.Instance().initialized = true;
    }
    
}
