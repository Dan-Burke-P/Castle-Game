using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="UnitUI/UnitUIData")]
public class UnitUIData : ScriptableObject{
    
    public string unitTitle = "untitled";
    public int maxHealth = 100;
    public int currentHealth = 75;
    public int maxActionPoints;
    public int currentActionPoints;

    public GameObject displayObject;
    
    public List<UnitActionData> actionList = new List<UnitActionData>();

}