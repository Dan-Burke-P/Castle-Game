using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCard: ScriptableObject{
    public string cardTitle;
    public string cardDescription;
    public int goldCost;
    public Sprite img;

    public GameObject displayObject;

    public abstract void playCard();


}
