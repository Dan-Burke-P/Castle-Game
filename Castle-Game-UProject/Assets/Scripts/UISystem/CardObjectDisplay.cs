using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardObjectDisplay : MonoBehaviour, IPointerClickHandler
{

    public BaseCard content;

    public Text title;
    public Text desc;
    public Text cost;

    public void setContent(BaseCard crd)
    {
        content = crd;
        
        title.text = crd.cardTitle;
        desc.text = crd.cardDescription;
        cost.text = $"{crd.goldCost}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        content.playCard();
    }
}
