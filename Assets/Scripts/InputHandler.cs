using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the user input and dispatches events based on what the player is doing
public class InputHandler : MonoBehaviour{
    
    // The unit currently selected
    public GameObject selectedUnit;

    // The transform component of the selection indicator
    public Transform selectionIndicator;
    
    public Material slctMat;
    
    public Color rstColor = new Color();

    // The Board Space for the input handler to get data from
    public BoardSpace bs;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)){
            if (hit.transform.tag.Equals("GameBoard")){
                Vector3 selectionLocation = new Vector3();

                selectionLocation.x = (float)Math.Floor(hit.point.x) + .5f;
                selectionLocation.y = .01f;
                selectionLocation.z = (float)Math.Floor(hit.point.z) + .5f;
              
                selectionIndicator.position = selectionLocation;

//                BaseUnit tmp = bs.getPieceAtLoc((int)Math.Floor(hit.point.x), (int)Math.Floor(hit.point.z));
//                if (tmp != null){
//                    Debug.Log(tmp.name);
//                }
            }        
            else{
                
            }
        
        }
        else{
            
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
