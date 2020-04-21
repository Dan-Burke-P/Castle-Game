using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.InputSystem;
using EventSystem;
using GameManagers;
using UnityEngine;

public class selectUnitOnBoard : MonoBehaviour{
    public BoardSpace BADBS;
    public BaseUnit test;
    public BaseUnit selection;
    
    
    EventDefinition unitUIpanel = new EventDefinition(SysTarget.UI, "setUnitPanelData");
    
    private void Start(){
        print(FInput.Instance);
        FInput.Instance.RegisterButtonToPoll("Fire1");
        FInput.Instance.RegisterCallback("BDown:Fire1",false, clickCallBack);
    }

    public void clickCallBack(){

        if (!UIHOVERSTATUS.hovered && GameMaster.Instance.selectionMode){
            // If we are not interacting with the UI
            Vector2Int location = new Vector2Int(FInput.Instance.MouseOverTile.x, FInput.Instance.MouseOverTile.y);
            //print("Selected unit at : " + location);
        
            BaseUnit trg = BADBS.getPieceAtLoc(location);

            if (trg){
                if (selection){
                    selection.shouldHighlight = false;
                }
                selection = trg;
                trg.shouldHighlight = true;
                unitUIpanel.raise(0, this, new Dictionary<string, object>(){
                    {"BaseUnit", selection}
                });
            }
            else{
                if (selection){
                    if (!selection.moveMode){
                        selection.shouldHighlight = false;
                        selection = null;
                        unitUIpanel.raise(0, this, new Dictionary<string, object>(){
                            {"BaseUnit", selection}
                        });
                    }
                }
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
