using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.InputSystem;
using GameManagers;

[CreateAssetMenu(menuName="ScriptableObjects/Soldier")]
public class CRD_SU_soldier :  BaseCard
{
    private void OnEnable(){
        cardTitle = "Create Soldier";
        goldCost = 100;
        cardDescription = "Create a new soldier to fight for the king";
        img = Resources.Load("Images/SoldierArt.png") as Sprite;
    }

    public override void playCard(){
        spawnSoldier();
    }
    
    public void spawnSoldier(){
        FInput.Instance.RegisterCallback("BDown:Fire1",true, onClick);
    }

    public void onClick(){

        Debug.Log("Spawning unit!");
        Vector2Int location = FInput.Instance.MouseOverTile;
        BaseUnit bu = UnitFactory.Instance().CreateUnit<UNIT_Soldier>(location);
        GameMaster.Instance.bs.addUnitAt(bu, location);
        
    }
}
