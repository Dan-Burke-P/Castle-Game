using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    public string CardName;

    public int Cost;

    public GameObject PrefabCard;

    public GameObject giveCard(GameObject player)
    {
        return Instantiate(PrefabCard);
    }

}
