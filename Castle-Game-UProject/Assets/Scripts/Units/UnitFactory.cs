using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class UnitFactory
{
    private static readonly UnitFactory instance = new UnitFactory();

    public static UnitFactory Instance()
    {
        return instance;
    }
    public void CreateUnit<UnitClass> (Vector2Int coordinates) where UnitClass : BaseUnit
    {
        UnitClass unit = ScriptableObject.CreateInstance("BaseUnit") as UnitClass;
        unit.ID = UnitRegistry.setID();
        unit.xPos = coordinates.x;
        unit.yPos = coordinates.y;
        EventDefinition displayEvent = new EventDefinition(SysTarget.UI, "addUnitDisplayObject", this);
        displayEvent.raise(unit.ID, this, new Dictionary<string, object> { {"BaseUnit", unit} });
    }
}
