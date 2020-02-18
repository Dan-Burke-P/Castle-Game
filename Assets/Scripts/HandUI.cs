using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    float counter = 1;
    public RectTransform crd;
    float center;
    public RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent(typeof(RectTransform)) as RectTransform;
        Debug.Log(rt.rect);
    }

    // Update is called once per frame
    void Update()
    {
        center = rt.rect.width / 2;
        counter -= Time.deltaTime;
        crd.anchoredPosition = new Vector2(center, 50);
        if(counter < 0)
        {
            counter = 1;
            Debug.Log(center);
        }
    }
}
