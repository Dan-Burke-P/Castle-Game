﻿using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="ScriptableObjects/Siege")]
public class CRD_SU_siege : BaseCard
{

    private void OnEnable(){
        badDB = CardImageDB.Instance();
        cardTitle = "Siege";
        goldCost = 300;
        cardDescription = "A war machine that excels at damaging enemy buildings";
        img = badDB.siegeArt;
    }

    public override void playCard(BoardSpace bs)
    {
        Debug.Log($"Playing {cardTitle}");
    }

}
