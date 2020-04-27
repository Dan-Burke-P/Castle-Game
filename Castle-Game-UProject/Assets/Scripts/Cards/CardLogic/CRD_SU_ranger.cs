using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="ScriptableObjects/Ranger")]
public class CRD_SU_ranger : BaseCard
{

    private void OnEnable(){
        badDB = CardImageDB.Instance();
        cardTitle = "Create Ranger";
        goldCost = 150;
        cardDescription = "Enlist a sharpshooter who can beset the enemy from afar";
        img = badDB.rangerArt;
    }

    public override void playCard(BoardSpace bs)
    {
        Debug.Log($"Playing {cardTitle}");
    }

}