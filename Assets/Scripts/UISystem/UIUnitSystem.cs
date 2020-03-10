using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


/*
 * Handles displaying information related to units and their actions
 * 
 */
public class UIUnitSystem : MonoBehaviour {


    private string _unitName;

    public Text nameText;
    /// <summary>
    /// displayUnitUI is the final point of the unit data in the UI system,
    /// it will bring up and display the relevant data in the passed unit object
    /// </summary>
    /// <param name="data">
    /// The unit data to display
    /// </param>
    public void displayUnitUI(BaseUnit data){
        
        // TODO add a way for the unit to dynamically supply a list of action keys for it
        // TODO add a way for the unit to dynamically supply stats that might be variable but keep updated in real time

        _unitName = data.unitName;

    }

    /// <summary>
    /// Enables and renders the unit UI section
    /// </summary>
    public void renderUI(){
        nameText.text = _unitName;
    }

    /// <summary>
    /// Hides the UI elements and suspends updating UI elements 
    /// </summary>
    public void hideUI(){
        
    }

}
