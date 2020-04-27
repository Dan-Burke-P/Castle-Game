using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="ScriptableObjects/Medic")]
public class CRD_SU_medic : BaseCard
{

    private void OnEnable(){
        badDB = CardImageDB.Instance();
        cardTitle = "Create Medic";
        goldCost = 200;
        cardDescription = "Call in a licensed professional to heal your wounded";
        img = badDB.medicArt;
    }

    public override void playCard(BoardSpace bs)
    {
        Debug.Log($"Playing {cardTitle}");
    }

}