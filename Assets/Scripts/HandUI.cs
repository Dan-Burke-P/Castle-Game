using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class HandUI : MonoBehaviour
{
    float counter = 1;
    public List<RectTransform> crd;
    float center;
    public RectTransform rt;

    public GameObject template;
    
    public List<Vector2> slots = new List<Vector2>();
    
    public Hand plyr;

    public EventListener addToHandEvent;
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }


    private void addToHand(Dictionary<string, object> varg)
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

        GameObject template = Instantiate(this.template, gameObject.transform, true);

        template.GetComponent<BaseCard>().setCardData(c);
        
        crd.Add(template.GetComponent<RectTransform>());
    }
    
    void Start()
    {
        addToHandEvent.registerAction(addToHand);
    }
    
    [ContextMenu("Display Hand")]
    public void DisplayHand()
    {
        if (plyr.cards.Count > 0)
        {
            int divs = (int)(rt.rect.width / plyr.cards.Count);
            divs = (int)rt.rect.width / divs;
            for (int i = 0; i < divs; i++)
            {
                slots.Add(new Vector2(i * (rt.rect.width / divs), 25));
            }

            for (int j = 0; j < slots.Count; j++)
            {
                crd[j].anchoredPosition = slots[j];
            }
       
            slots.Clear();
        }
    }
}
