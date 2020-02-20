using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    float counter = 1;
    public List<RectTransform> crd;
    float center;
    public RectTransform rt;

    public List<Vector2> slots = new List<Vector2>();
    
    public Hand plyr;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
