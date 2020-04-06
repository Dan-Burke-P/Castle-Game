using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hand")]

public class Hand : ScriptableObject
{
    public int maxHandSize;
    public List<Card> cards;

    public EventListener addToHand;
    public EventListener removeFromHand;


    public void init()
    {
        cards.Clear();
        addToHand.registerAction(addCardToHand);
    }

    public void addCardToHand(Dictionary<string, object> varg)
    {
        object obj;
        if(!varg.TryGetValue("card", out obj))
        {
            throw new ApplicationException("Raised add card without a card field");    
        }
        if (!(obj is Card))
        {
            throw new ApplicationException("Card field in add card event was not a card");
        }

        Card c = obj as Card;
        cards.Add(c);
        Debug.Log(" Adding Card to hand event triggered in hand");
    }
    

}
