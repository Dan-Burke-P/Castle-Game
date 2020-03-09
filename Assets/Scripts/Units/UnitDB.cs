using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitDB{
    
    public static GameObject uTmplt = Resources.Load(
        "UnitTemplate", typeof(GameObject)
        ) as GameObject;
    
    public static BaseUnit UNCR_Soldier(){
        BaseUnit bs = ScriptableObject.CreateInstance<UNIT_Soldier>();
        return bs;
    }
}
