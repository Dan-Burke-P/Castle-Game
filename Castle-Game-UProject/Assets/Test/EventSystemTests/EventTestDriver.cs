using System;
using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using UnityEngine.UI;
public class EventTestDriver : MonoBehaviour{

    public Text ESPrintOut;
    public GameObject go;
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

    public void removeEventSO(){
        EventDefinition tmp = new EventDefinition(def.sysTarget, def.target, this);
        
        tmp.deregister(testFunction);
        updateReadOut();
    }

    public void raiseEventSO(){
        EventDefinition tmp = new EventDefinition(def.sysTarget, def.target, this);
        
        tmp.raise(0, new Dictionary<string, object>{
            {"x", 5},
            {"y", 3}
        });
    }
    
    /// <summary>
    /// Expected params
    /// "x" : x-cord
    /// "y" : y-cord
    /// </summary>
    /// <param name="prms"></param>
    /// <param name="ID"></param>
    /// <param name="caller"></param>
    public void testFunction(Dictionary<string, object> prms, int ID, object caller){
        Debug.Log("Test Function Is Called by: " + caller.ToString() + " With ID: " + ID);

        object x;
        object y;
        
        if (!prms.TryGetValue("x", out x)){
            Debug.LogError("Message did not contain x parameter in dictionary");
            return;
        }
        
        if (!prms.TryGetValue("y", out y)){
            Debug.LogError("Message did not contain y parameter in dictionary");
            return;
        }

        int xCord = x is int ? (int) x : 0;
        int yCord = y is int ? (int) y : 0;
        
        Debug.Log(x);
    }
    
}
