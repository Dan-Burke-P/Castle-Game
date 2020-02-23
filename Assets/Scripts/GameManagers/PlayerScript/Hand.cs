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
        Debug.Log(" Adding Card to hand event triggered in hand SO ");
    }
    

}
