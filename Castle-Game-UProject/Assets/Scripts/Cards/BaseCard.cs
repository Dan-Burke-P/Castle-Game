using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCard: ScriptableObject{
    public string cardTitle;
    public string cardDescription;
    public int goldCost;

    public GameObject displayObject;

    public abstract void playCard();


}
