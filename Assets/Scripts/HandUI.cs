using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    float counter = 1;
    public List<RectTransform> crd;
    float center;
    public RectTransform rt;

    public Hand plyr;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(rt.rect.width);
    }

    // Update is called once per frame
    void Update()
    {
        float divs = rt.rect.width / plyr.cards.Count;
        center = rt.rect.width / 2;
        
    }
}
