using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.InputSystem;
using Cards;
using GameManagers;

[CreateAssetMenu(menuName="ScriptableObjects/Soldier")]
public class CRD_SU_soldier :  BaseCard
{
    private void OnEnable(){
        badDB = CardImageDB.Instance();
        cardTitle = "Create Soldier";
        goldCost = 100;
        cardDescription = "Recruit a new soldier to fight for the king";
        img = badDB.soldierArt;
    }

    public override void playCard(BoardSpace bs){
        spawnSoldier(bs);
    }
    
    public void spawnSoldier(BoardSpace bs){
        FInput.Instance.RegisterCallback("BDown:Fire1",true, onClick(bs));
    }

    public Action onClick(BoardSpace bs){ // Get rid of the bs parameter after finding the BoardSpace of the GameMaster

        Debug.Log("Spawning unit!");
        Vector2Int location = FInput.Instance.MouseOverTile;
        BaseUnit bu = UnitFactory.Instance().CreateUnit<UNIT_Soldier>(location);
        bs.addUnitAt(bu, location); // Get rid of this after making the following line work
        //GameMaster.Instance.bs.addUnitAt(bu, location);
        return null;

    }
}
