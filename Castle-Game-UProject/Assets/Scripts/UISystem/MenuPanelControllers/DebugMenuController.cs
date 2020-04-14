using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenuController : MonoBehaviour{


    public GameObject UnitPanel;
    public GameObject CardPanel;
    public void hideAll(){
        UnitPanel.SetActive(false);
        CardPanel.SetActive(false);
    }
    
    /*
     * The following functions are all used as end points for menu options in the debug panel
     * and will invoke some sort of behaviour for testing purposes
     */

    #region ButtonFunctions

    

    #endregion

    /*
     * Defines functions for executing commands related to the add unit debug options
     */
    #region AddUnitPanelFunctions

    public void showUnitSpawnMenu(){
        hideAll();
        UnitPanel.SetActive(true);
    }
    

    #endregion
    
    
    /*
     * Defines functions for executing commands related to the add card debug options
     */
    #region AddUnitPanelFunctions

    public void showCardSpawnMenu(){
        hideAll();
        CardPanel.SetActive(true);
    }

    #endregion
}
