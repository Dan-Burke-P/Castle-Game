using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : ScriptableObject{
    
    public string unitName = "Error Instantiated as a Base Unit";
    public int xPos, yPos;

    public GameObject obj;
    public Transform tranform;
    
    public void move(int x, int y){
        
    }

}
