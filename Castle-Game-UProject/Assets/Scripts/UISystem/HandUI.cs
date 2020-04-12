using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour{
    public DATAHandUI handData;
    public GameObject cardTemplate;
    public GameObject cardObjectParent;
    
    public void displayCards(){
        foreach (DATACardUI crd in handData.cards){
            if (crd != null){
                if (crd.renderedObject == null){
                    GameObject obj = createNewCardObject(crd);
                    obj.transform.SetParent(cardObjectParent.transform);
                    crd.renderedObject = obj;
                }
            }
        }
    }

    public GameObject createNewCardObject(DATACardUI data){
        GameObject obj = Instantiate(cardTemplate);
        CardObjectDisplay cod = obj.GetComponent<CardObjectDisplay>();
        cod.setContent(data);
        return obj;
    }

    private void Update(){
        displayCards();
    }
}
