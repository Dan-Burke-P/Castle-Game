using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHMonitor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
   
    public bool hovered = false;
    
    public void OnPointerEnter(PointerEventData eventData){
        hovered = true;
        UIHOVERSTATUS.hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData){
        hovered = false;
        UIHOVERSTATUS.hovered = false;
    }
}
