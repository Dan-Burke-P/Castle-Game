using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRD_SU_soldier :  MonoBehaviour, IBaseCard
{
    public int cost { get; set; }
    public CardType type { get; set; }


    public void play()
    {
        Debug.Log("Playing create soldier");
    }
}
