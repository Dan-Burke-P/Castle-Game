using System;
using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;

public class HandUI : MonoBehaviour{
    public GameObject cardTemplate;
    public GameObject cardObjectParent;
    
    private void Awake(){
        EventDefinition ed = new EventDefinition(SysTarget.UI, "displayHand", this);
        ed.register(displayHand);
    }

    /// <summary>
    /// Event for when the hand has been updated and the UI needs to redisplay it
    /// </summary>
    /// <param name="prms"></param>
    /// <param name="ID"></param>
    /// <param name="caller"></param>
    public void displayHand(Dictionary<string, object> prms, int ID, object caller){
        object tmp;

        if (!prms.TryGetValue("Hand", out tmp)){
            Debug.LogError("Message did not contain 'Hand' parameter in dictionary");
            return;
        }

        Hand hand = tmp as Hand;

        if (hand)
        {
            foreach (BaseCard crd in hand.cards){
                if (crd.displayObject == null)
                {
                    GameObject obj = createNewCardObject(crd);
                    obj.transform.SetParent(cardObjectParent.transform);
                    crd.displayObject = obj;
                }
            }
        }
        else
        {
            Debug.LogError("'Hand' parameter is null or not a Hand object");
        }
    }

    public GameObject createNewCardObject(BaseCard crd){
        GameObject obj = Instantiate(cardTemplate);
        CardObjectDisplay cod = obj.GetComponent<CardObjectDisplay>();
        cod.setContent(crd);
        return obj;
    }
}
