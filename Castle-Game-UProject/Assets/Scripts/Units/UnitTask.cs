using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitTask {
    
    public UnityAction ua;
    public string displayName;
    public int APcost;

    public UnitTask(UnityAction _ua, string _displayName, int _APcost){
        ua = _ua;
        displayName = _displayName;
        APcost = _APcost;
    }
}
