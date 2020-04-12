using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDisplayObject : MonoBehaviour{
    
    public UnitUIData content;

    public Transform unitMeshParent;
    public GameObject unitDisplayObject;

    public RadialProgBar rpb;


    public void setContent(UnitUIData uid){
        content = uid;
        setContent();
    }
    public void setContent(){
        if (!unitDisplayObject){
            unitDisplayObject = Instantiate(content.displayObject, unitMeshParent, false);
        }
        else{
            Destroy(unitDisplayObject);
            unitDisplayObject = Instantiate(content.displayObject, unitMeshParent, false);
        }

        rpb.max = content.maxHealth;
    }
    public void display(){
        rpb.max = content.maxHealth;
        rpb.setCurrent(content.currentHealth);
    }

    private void Start(){
        setContent();
    }

    private void Update(){
        display();
    }
}
