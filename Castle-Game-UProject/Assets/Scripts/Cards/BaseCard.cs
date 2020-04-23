using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCard: ScriptableObject{
    public string cardTitle;
    public string cardDescription;
    public int goldCost;
    public Sprite img;
    public CardImageDB badDB;
    
    
    public GameObject displayObject;

    public abstract void playCard();


}
