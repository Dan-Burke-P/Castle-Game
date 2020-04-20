using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObjectDisplay : MonoBehaviour{

    public Text title;
    public Text desc;
    public Text cost;
    
    

    public void setContent(DATACardUI cnt){
        title.text = cnt.title;
        desc.text = cnt.cardText;
        cost.text = $"{cnt.cost}";
    }
    
    public void setContent(Card crd){
        title.text = crd.title;
        //desc.text = crd.cardText;
        desc.text = "Card Description Text";
        //cost.text = $"{crd.cost}";
        cost.text = "int x";
    }
    
}
