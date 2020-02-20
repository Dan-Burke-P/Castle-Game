using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/Soldier")]
public class CRD_SU_soldier :  Card
{
    
    public int cost;
    
    public CRD_SU_soldier()
    {
        title = "Create Soldier";
        type = CardType.Unit;
    }
    
    
    public override void play()
    {
        Debug.Log($"Playing {title}");
    }
    

}
