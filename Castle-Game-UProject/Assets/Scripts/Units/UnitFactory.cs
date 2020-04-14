using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using GameManagers;

public class UnitFactory
{
    private static readonly UnitFactory instance = new UnitFactory();

    public static UnitFactory Instance()
    {
        return instance;
    }
    public BaseUnit CreateUnit<UnitClass> (Vector2Int coordinates) where UnitClass : BaseUnit
    {
        UnitClass unit = ScriptableObject.CreateInstance<UnitClass>();
        unit.ID = UnitRegistry.setID();
        unit.xPos = coordinates.x;
        unit.yPos = coordinates.y;
        unit.ownerID = GameMaster.Instance.getActivePlayer();
       
        return unit;
    }
}
