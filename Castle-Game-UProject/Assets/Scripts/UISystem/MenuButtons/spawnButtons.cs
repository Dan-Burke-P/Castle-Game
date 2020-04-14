using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.InputSystem;
using UnityEngine;
using Assets.Scripts.InputSystem;

public class spawnButtons : MonoBehaviour{
    
    
    public BoardSpace BADBS;
    /// <summary>
    /// Work around variable until deregistering of input is added
    /// </summary>
    public bool spawning = false;
    private void Update(){
        
    }

    public void spawnSoldier(){
        FInput.Instance.RegisterCallback("BDown:Fire1", onClick);
        spawning = true;

    }

    public void onClick(){

        if (spawning){
            Vector2Int location = FInput.Instance.MouseOverTile;
            BaseUnit bu = UnitFactory.Instance().CreateUnit<UNIT_Soldier>(location);
            BADBS.addUnitAt(bu, location);
            spawning = false;

        }
        
    }
    

}
