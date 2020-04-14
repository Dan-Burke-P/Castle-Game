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
    [SerializeField]
    private bool spawningMode;
    private void Update(){
        
    }

    public void Start(){
        // This is just a place holder until the input system gets refined more
    }

    public void spawnSoldier(){
        FInput.Instance.RegisterCallback("BDown:Fire1",true, onClick);
    }

    public void onClick(){

        print("Spawning unit!");
        Vector2Int location = FInput.Instance.MouseOverTile;
        BaseUnit bu = UnitFactory.Instance().CreateUnit<UNIT_Soldier>(location);
        BADBS.addUnitAt(bu, location);
        spawningMode = false;
        

            
    }
    

}
