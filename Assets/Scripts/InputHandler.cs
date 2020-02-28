using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the user input and dispatches events based on what the player is doing
public class InputHandler : MonoBehaviour{
    
    public GameObject selectedUnit;
    public Material slctMat;
    
    public Color rstColor = new Color();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)){
            if (hit.transform.tag.Equals("UnitTemplate")){
                ChangeSelectedUnit(hit.transform.gameObject);
            }
            else{
                ClearUnitSelection();
            }
        }
        else{
            ClearUnitSelection();
        }

        if (selectedUnit != null && Input.GetMouseButtonDown(0)){
            BaseUnit bu = selectedUnit.GetComponent<UnitHandler>().unitData;
            Debug.Log($"Pressed on a {bu.name} unit");
        }
   
    }

    public void ChangeSelectedUnit(GameObject go){
        slctMat = go.GetComponent<MeshRenderer>().material;
        
        if (selectedUnit == null){
            selectedUnit = go;
            // If we don't have a unit selected just select it
            rstColor = slctMat.GetColor("_Color");
            
            slctMat.SetColor("_Color", Color.black);
        }
        else{
            // First we need to deselect the current unit
            // second we need to select the new unit
            //ClearUnitSelection();
        }
        //hit.transform.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
    }

    public void ClearUnitSelection(){
        if (selectedUnit != null){
            slctMat.SetColor("_Color", rstColor);
            selectedUnit = null;
            rstColor = new Color();
            slctMat = null; 
        }
        
    }
}
