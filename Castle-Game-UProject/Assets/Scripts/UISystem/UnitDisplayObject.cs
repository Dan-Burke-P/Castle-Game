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
    

    public void setContent(BaseUnit uid){
        content = uid;
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
    }
    public void display(){
        rpb.max = content.maxHP;
        rpb.setCurrent(content.currHP);
        if (content.shouldHighlight && !highlightObject.activeInHierarchy){
            highlightObject.SetActive(true);
        }else if (!content.shouldHighlight && highlightObject.activeInHierarchy){
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
}
