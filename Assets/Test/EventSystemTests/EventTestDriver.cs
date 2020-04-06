using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using UnityEngine.UI;
using EventSystem;
public class EventTestDriver : MonoBehaviour{
    
    
    
    public Text ESPrintOut;

    public EventDefSO def;
    // Start is called before the first frame update
    void Start()
    {
        updateReadOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Prints the event system to console for debug
    /// </summary>
    public void printEventSystem(){
        Debug.Log(EventBus.Instance().getEventSystemString());
    }

    /// <summary>
    /// Updates the text box readout
    /// </summary>
    public void updateReadOut(){
        ESPrintOut.text = EventBus.Instance().getEventSystemString();
    }

    public void addEventSO(){
        EventDefinition tmp = new EventDefinition(def.sysTarget, def.target, this);
        
        tmp.register(testFunction);
        updateReadOut();
    }

    public void raiseEventSO(){
        EventDefinition tmp = new EventDefinition(def.sysTarget, def.target, this);
        
        tmp.raise(0, new Dictionary<string, object>{});
    }
    public void testFunction(Dictionary<string, object> prms, int ID, object caller){
        Debug.Log("Test Function Is Called by: " + caller.ToString() + " With ID: " + ID);
    }
    
}
