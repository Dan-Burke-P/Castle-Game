using System;
using System.Collections.Generic;
using EventSystem;
using GameManagers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;


/*
 * Handles displaying information related to units and their actions
 * 
 */
namespace UISystem{
    public class UnitUIPanel : MonoBehaviour{

        public bool hovered = false;
        public GameObject panelObject;
        
        private BaseUnit selection;

        public Text unitNameText;
        
        public Slider healthBar;
        public Text healthText;

        public Text actionPointText;

        public Text ownerText;
        /// <summary>
        /// This is a temporary way of holding the link to the action UI objects
        /// in the final release this needs to be changed to a dynamic system that creates
        /// the objects
        /// </summary>
        public List<UnitActionDisplay> actionObjects;
        
        
        public GameObject unitUIPanel;
        
        /// <summary>
        /// displayUnitUI is the final point of the unit data in the UI system,
        /// it will bring up and display the relevant data in the passed unit object
        /// </summary>
        /// <param name="unitUiData">
        /// Data we want to display
        /// </param>
        public void displayUnitUI(BaseUnit bu){
            selection = bu;
            loadActionList();
            ownerText.text = $"Owner: {bu.ownerID}";
            renderUI();
            showUI();
        }

        /// <summary>
        /// Sets up buttons on the UI to be used to display and call actions in the system
        /// </summary>
        public void loadActionList(){

            // Check if the owner is the active player before presenting the options to the player
            if (GameMaster.Instance.isPlayerActive(selection.ownerID)){
                for (int i = 0; i < selection.actions.Count; i++){
                    if (i > 3) break; // This is an incomplete method and this just serves to prevent errors until the method is improved
                    actionObjects[i].gameObject.SetActive(true);
                    actionObjects[i].setAction(selection.actions[i]);
                } 
            }
            
            
        }
        
        /// <summary>
        /// Enables and renders the unit UI section
        /// </summary>
        public void renderUI(){
            unitNameText.text = selection.unitName;
            healthBar.maxValue = selection.maxHP;
            healthBar.value = selection.currHP;

            healthText.text = $"{selection.maxHP}/{selection.currHP}";
            actionPointText.text = $"AP: {selection.currAP}/{selection.maxAP}";

            
        }

        /// <summary>
        /// Hides the UI elements and suspends updating UI elements 
        /// </summary>
        public void hideUI(){
            for (int i = 0; i < actionObjects.Count; i++){
                if (i > 3) break; // This is an incomplete method and this just serves to prevent errors until the method is improved
                actionObjects[i].gameObject.SetActive(false);
            } 
            panelObject.SetActive(false);
        }

        /// <summary>
        /// Shows the unit panel
        /// </summary>
        public void showUI(){
            panelObject.SetActive(true);
        }

        private void Awake(){
            EventDefinition ed = new EventDefinition(SysTarget.UI, "setUnitPanelData", this);
            ed.register(setUnitPanelData);
        }

        private void Update(){
            if (selection){
                renderUI();   
            }
        }


        #region EventFunctions

        /// <summary>
        /// Event for when a unit needs to be displayed on a panel
        /// if the passed unit parameter is null instead just hide the panel
        /// </summary>
        /// <param name="prms"></param>
        /// <param name="ID"></param>
        /// <param name="caller"></param>
        public void setUnitPanelData(Dictionary<string, object> prms, int ID, object caller){
            //print("Adding display object to the game");
            if (!hovered){
                object tmp;
        
                if (!prms.TryGetValue("BaseUnit", out tmp)){
                    Debug.LogError("Message did not contain x parameter in dictionary");
                    return;
                }

                BaseUnit _baseUnit = tmp as BaseUnit;

                if (_baseUnit){
                    displayUnitUI(_baseUnit);
                }
                else{
                    hideUI();
                }
            }

        }
        

        #endregion

        
    }
}
