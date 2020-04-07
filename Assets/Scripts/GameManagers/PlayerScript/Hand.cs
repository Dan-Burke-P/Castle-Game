using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hand")]

public class Hand : ScriptableObject
{
    public List<Card> cards; // All the cards in the hand
    public int currentIndex; // Index of the card in the hand that's currently being selected

    //public EventListener addToHand;
    //public EventListener removeFromHand;
    
    public Hand()
    {
        cards = new List<Card>();
        currentIndex = -1;
    }

    public void init()
    {
        cards.Clear();
        //addToHand.registerAction(addCardToHand);
    }
    
    //Expecting param "card", which contains a Card object
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

        // If you no longer have an empty hand, show the first card in your hand
        if (cards.Count == 1)
        {
            currentIndex = 0;
        }
    }

    // Expecting param "index", an int specifying the index of the card in the hand to be removed (from 0 to cards.Count - 1)
    public void removeCardFromHand(Dictionary<string, object> varg)
    {
        object obj;
        if(!varg.TryGetValue("index", out obj))
        {
            throw new ApplicationException("Raised remove card without an index field");    
        }
        if (!(obj is int))
        {
            throw new ApplicationException("Index field in add card event was not an int");
        }

        int index = (int) obj;

        if (index >= cards.Count || index < 0)
        {
            throw new ApplicationException("\"index\" value passed to remove function not a valid index in the hand");
        }

        cards.RemoveAt(index);

        // If you were looking at the last card in the hand, make sure you're still doing that after the size decreases
        if (currentIndex == cards.Count)
        {
            currentIndex--;
        }
    }
    

}
