using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour
{


    public void testAction(Dictionary<string, object> objs){
        Debug.Log("Test action was invoked");
    }
    
    
    public void TEST_RaiseEvent(){
        EventDefinition ed = new EventDefinition();
        ed.eventName = "RaiseTestEvent";
        ed.eventTarget = "testAction";

        EventBus.Instance().raiseEvent(ed, new Dictionary<string, object>());
    }

    public void TEST_RegisterEvent(){
        Debug.Log("Testing event register");
        EventBus.Instance().RegisterEvent(new EventDefinition());
    }

    public void TEST_createNewEventType(){
        Debug.Log("Testing registering a new event");

        // Create a test event type
        EventBus.Instance().CreateNewEventType("RaiseTestEvent");
        
        // Create a new event definition to invoke our test function
        EventDefinition ed = new EventDefinition();
        ed.eventName = "RaiseTestEvent";
        ed.eventTarget = "testAction";
        ed.action = testAction;
        
        // Register the new event so it will listen
        EventBus.Instance().RegisterEvent(ed);
    }

    public void TEST_raiseMoveUnit(){
        EventDefinition ed = new EventDefinition();
        ed.eventName = "MoveUnit";
        ed.eventTarget = "MoveTargetUnit";
        
        Dictionary<string, object> prms = new Dictionary<string, object>();
        prms.Add("x", 5f);
        prms.Add("y", 5f);
        
        EventBus.Instance().raiseEvent(ed, prms);
    }

    public void TEST_raiseAddUnit(){
        EventDefinition ed = new EventDefinition();
        ed.eventName = "AddUnitToBoard";
        ed.eventTarget = "addBaseUnit";
        
        Dictionary<string, object> prms = new Dictionary<string, object>();
        BaseUnit bs = UnitDB.UNCR_Soldier();

        bs.xPos = 4;
        bs.yPos = 3;
        
        prms.Add("unitData", bs);

        EventBus.Instance().raiseEvent(ed, prms);
    }
}
