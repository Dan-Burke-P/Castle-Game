using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="Soldier", menuName="Unit/Soldier")]
public class UNIT_Soldier : BaseUnit {
    
    public UNIT_Soldier() {
        unitName = "Soldier";
		vsSiege = 1.5f;
        
    }
    
    private void OnEnable(){
        displayObject = Resources.Load("Prefabs/UnitDisplayObjects/SoldierDisplayObject") as GameObject;
        
        base._init();
    }
}
