using System.Collections;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
using UnityEngine.Events;

public class UnitUITESTDRIVER : MonoBehaviour{
    
    public UnitUIPanel testPanel;
    public UnitUIData UIData;
    
    // Start is called before the first frame update
    void Start()
    {
        //testPanel.displayUnitUI(UIData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Func1(){
        Debug.Log("Test function 1 has been called");
    }
}
