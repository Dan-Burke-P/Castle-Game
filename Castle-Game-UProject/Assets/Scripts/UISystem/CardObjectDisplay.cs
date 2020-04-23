using System;
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
    public Image img;
    public void setContent(BaseCard crd)
    {
        content = crd;
        
        title.text = crd.cardTitle;
        desc.text = crd.cardDescription;
        cost.text = $"{crd.goldCost}";

        img.sprite = content.img;
    }

    private void Start(){
        if (content){
            setContent(content);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        content.playCard();
    }
}
