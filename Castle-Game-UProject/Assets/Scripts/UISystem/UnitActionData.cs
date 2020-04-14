using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="UnitUI/UnitActionData")]
public class UnitActionData : ScriptableObject{
    
    public UnityAction onClick = testFunc1;
    public string actionTitle;
    public int apCost;

    public static void testFunc1(){
        Debug.Log("Test func called");
    }
}