using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Handles displaying information related to units and their actions
 * 
 */
namespace UISystem{
    public class UnitUIPanel : MonoBehaviour{


        private UnitUIData selection;

        public Text unitNameText;
        
        public Slider healthBar;
        public Text healthText;

        public Text actionPointText;

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
        public void displayUnitUI(UnitUIData unitUiData){
            selection = unitUiData;
            renderUI();
            unitUIPanel.SetActive(true);
            
        }

        /// <summary>
        /// Enables and renders the unit UI section
        /// </summary>
        public void renderUI(){
            unitNameText.text = selection.unitTitle;
            healthBar.maxValue = selection.maxHealth;
            healthBar.value = selection.currentHealth;

            healthText.text = $"{selection.maxHealth}/{selection.currentHealth}";
            actionPointText.text = $"AP: {selection.currentActionPoints}/{selection.maxActionPoints}";
            
            updateActionList();
        }

        /// <summary>
        /// Updates the UI for the users action list
        /// </summary>
        public void updateActionList(){
            for (int i = 0; i < selection.actionList.Count; i++){
                if (i > 3) break; // This is an incomplete method and this just serves to prevent errors until the method is improved
                actionObjects[i].gameObject.SetActive(true);
                actionObjects[i].setAction(selection.actionList[i]);
            }
        }
        
        /// <summary>
        /// Hides the UI elements and suspends updating UI elements 
        /// </summary>
        public void hideUI(){
            
        }


        private void Update(){
            renderUI();
        }
    }
}
