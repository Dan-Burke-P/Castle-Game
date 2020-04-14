using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObjectDisplay : MonoBehaviour{

    public DATACardUI content;

    public Text title;
    public Text desc;
    public Text cost;
    
    

    public void setContent(DATACardUI cnt){
        title.text = cnt.title;
        desc.text = cnt.cardText;
        cost.text = $"{cnt.cost}";
    }
    // Start is called before the first frame update
    void Start()
    {
        setContent(content);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
