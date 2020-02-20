using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CRD_SU_siege : Card
{

    
    public CRD_SU_siege()
    {
        title = "Siege";
        type = CardType.Unit;
    }

    public override void play()
    {
        Debug.Log($"Playing {title}");
    }


}
