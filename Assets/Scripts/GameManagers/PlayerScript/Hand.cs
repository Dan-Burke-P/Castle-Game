using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hand")]
public class Hand : ScriptableObject
{
    public int maxHandSize;
    public List<Card> cards;

    public void addCardToHand(Card card)
    {
        cards.Add(card);
    }
}
