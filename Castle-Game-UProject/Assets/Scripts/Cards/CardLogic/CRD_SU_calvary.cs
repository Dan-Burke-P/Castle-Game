using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="ScriptableObjects/Calvary")]
public class CRD_SU_calvary : BaseCard
{

    private void OnEnable(){
        badDB = CardImageDB.Instance();
        cardTitle = "Create Calvary";
        goldCost = 250;
        cardDescription = "Deploy a mounted unit with incredible speed";
        img = badDB.calvaryArt;
    }

    public override void playCard(BoardSpace bs)
    {
        Debug.Log($"Playing {cardTitle}");
    }

}