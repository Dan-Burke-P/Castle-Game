using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosablePanel : MonoBehaviour{

    public RectTransform rt;
    private Rect r;
    
    public float openPosition;
    public float closedPosition;

    public Button openToggle;
    // Start is called before the first frame update
    void Start(){
        r = rt.rect;
        closePanel();
    }

    public void closePanel(){   
        openToggle.onClick.RemoveAllListeners();
        openToggle.onClick.AddListener(openPanel);
        rt.anchoredPosition = new Vector2(0, closedPosition);
        openToggle.GetComponentInChildren<Text>().text = "Open";
    }

    public void openPanel(){
        openToggle.onClick.RemoveAllListeners();
        openToggle.onClick.AddListener(closePanel);
        rt.anchoredPosition = new Vector2(0, openPosition);
        openToggle.GetComponentInChildren<Text>().text = "Close";
    }
    
}
