using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class HandEventHandler
{
    private static readonly HandEventHandler instance = new HandEventHandler();
    public EventDefinition addEvent;
    
    public HandEventHandler() {
        addEvent = new EventDefinition(SysTarget.Player, "addCardToHand", this);
        addEvent.register(addCardToHand);
    }

    public static HandEventHandler Instance()
    {
        return instance;
    }

    /// <summary>
    /// Used for adding a given card to a given hand
    /// </summary>
    /// <param name="Card">
    /// The card we want to add to a hand
    /// </param>
    /// <param name="Hand">
    /// The hand we want to add the card to
    /// </param>
    public void addCardToHand(Dictionary<string, object> prms, int ID, object caller)
    {
        object obj;
        if(!prms.TryGetValue("Card", out obj))
        {
            throw new ApplicationException("Raised 'add card to hand' without a card field");    
        }
        if (!(obj is BaseCard))
        {
            throw new ApplicationException("Card field in 'add card to hand' event was not a BaseCard");
        }

        BaseCard c = obj as BaseCard;
        
        if(!prms.TryGetValue("Hand", out obj))
        {
            throw new ApplicationException("Raised 'add card to hand' without a hand field");    
        }
        if (!(obj is Hand))
        {
            throw new ApplicationException("Hand field in 'add card to hand' event was not a hand");
        }

        Hand h = obj as Hand;
        
        h.addCardToHand(c);
    }
}