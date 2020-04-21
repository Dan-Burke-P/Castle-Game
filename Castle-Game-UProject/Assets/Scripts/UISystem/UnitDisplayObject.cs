using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDisplayObject : MonoBehaviour{

    public bool DEBUGshouldHighlight;
    
    public BaseUnit content;

    public Transform root;
    
    public Transform unitMeshParent;
    public GameObject unitDisplayObject;
    public GameObject highlightObject;
    
    public RadialProgBar rpb;
    public Color player1;
    public Color player2;
    public UnitOwnerDisplay ownerDisplay;
    public void setContent(BaseUnit uid){
        content = uid;
        content.udo = this;
        setContent();
    }
    public void setContent(){
        DEBUGshouldHighlight = true;
        if (!unitDisplayObject){
            unitDisplayObject = Instantiate(content.displayObject, unitMeshParent, false);
        }
        else{
            Destroy(unitDisplayObject);
            unitDisplayObject = Instantiate(content.displayObject, unitMeshParent, false);
        }

        rpb.max = content.maxHP;

        if (content.ownerID == 1){
            ownerDisplay.setDisplayColor(player1);
        }
        else{
            ownerDisplay.setDisplayColor(player2);
        }
        
    }
    public void display(){
        rpb.max = content.maxHP;
        rpb.setCurrent(content.currHP);
        if (content.shouldHighlight){
            highlightObject.SetActive(true);
        }else if (!content.shouldHighlight){
            highlightObject.SetActive(false);
        }
            root.localPosition = new Vector3(content.xPos,content.yPos,0);
    }

    private void Start(){
        setContent();
    }

    private void Update(){
        display();
    }

    public void removeDisplayObject(){
        print("Destroying display object");
        Destroy(gameObject);
    }
}
