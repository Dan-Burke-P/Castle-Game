﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This is the top level component of the UI system
 *
 * Everything concerned with the UI and the outside world should be funneled through this
 * function to the subsequent UI sub system that handles a specific thing
 *
 * For example if a player clicks on a unit and the input system wishes to display the
 * unit data on the screen instead of requesting that directly from the unit UI system
 * it will instead send the request here and this component will find and direct
 * the data
 * 
 */
public class UIHandler : MonoBehaviour
{

    /*
     * Takes in a unit and displays it's data on the UI
     */
    public void displayUnitData(BaseUnit data){
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
