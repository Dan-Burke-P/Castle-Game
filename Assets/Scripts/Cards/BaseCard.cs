using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard: MonoBehaviour
{

    public Card cardData;
    
    public void setCardData(Card c)
    {
        cardData = c;
        gameObject.name = c.title;
    }
    
}
