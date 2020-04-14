using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgBar : MonoBehaviour{

    public bool everyUpdate;
    
    public Gradient grd;
    
    public float min, max;
    [SerializeField]
    private float current;
    private float diff;
    private float fillPercent;
    
    public Image fill;

    public void calculate(){
        diff = max - min;
        fillPercent = current / diff;
        fill.fillAmount = fillPercent;
        fill.color = grd.Evaluate(fillPercent);
    }

    public void setCurrent(float f){
        current = f;
        calculate();
    }
    
    private void Update(){
        if (everyUpdate){
            calculate();    
        }
        
    }
}
