using System;
using System.Collections;
using System.Collections.Generic;
using EventSystem;
using GameManagers;
using UnityEngine;

[CreateAssetMenu(menuName = "Hand")]

public class Hand : ScriptableObject
{
    public List<BaseCard> cards; // All the cards in the hand
    public bool shouldDisplay; // Does the UI need to display this hand or not
    public int currentIndex; // Index of the card in the hand that's currently being selected

    public Hand()
    {
        cards = new List<BaseCard>();
        shouldDisplay = false;
        currentIndex = -1;
    }

    public void init()
    {
        cards.Clear();
    }
    
    // Adds a given card to the hand
    public void addCardToHand(BaseCard c)
    {
        cards.Add(c);
        
        // Signal Hand UI to redisplay Hand
        if (shouldDisplay)
        {
            EventDefinition handUI = new EventDefinition(SysTarget.UI, "displayHand");
            handUI.raise(0, this, new Dictionary<string, object>(){
                {"Hand", this}
            });
        }

        // If you no longer have an empty hand, show the first card in your hand
        if (cards.Count == 1)
        {
            currentIndex = 0;
        }
    }

    // Removes the card in the hand at the given index (from 0 to cards.Count - 1)
    public void removeCardFromHand(int index)
    {
        if (index >= cards.Count || index < 0)
        {
            throw new ApplicationException("\"index\" value passed to remove function not a valid index in the hand");
        }

        Destroy(cards[index].displayObject);
        cards.RemoveAt(index);

        // Signal Hand UI to redisplay Hand
        if (shouldDisplay)
        {
            EventDefinition handUI = new EventDefinition(SysTarget.UI, "displayHand");
            handUI.raise(0, this, new Dictionary<string, object>(){
                {"Hand", this}
            });
        }

        // If you were looking at the last card in the hand, make sure you're still doing that after the size decreases
        if (currentIndex == cards.Count)
        {
            currentIndex--;
        }
    }
    

}
