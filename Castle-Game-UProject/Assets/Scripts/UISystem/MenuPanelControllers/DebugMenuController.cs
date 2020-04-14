using System.Collections;
using System.Collections.Generic;
using GameManagers;
using UnityEngine;

public class DebugMenuController : MonoBehaviour{


    public GameObject UnitPanel;
    public GameObject CardPanel;
    public GameObject PlayerDataPanel;
    public void hideAll(){
        UnitPanel.SetActive(false);
        CardPanel.SetActive(false);
        PlayerDataPanel.SetActive(false);
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
    #region AddCardPanelFunctions

    public void showCardSpawnMenu(){
        hideAll();
        CardPanel.SetActive(true);
    }

    #endregion

    /*
     * Functions for the player data panel
     */
    #region PlayDataPanelFunctions

    public void showPlayerDataPanel(){
        hideAll();
        PlayerDataPanel.SetActive(true);
    }

    public void changeActivePlayer(){
        GameMaster.Instance.changeActivePlayer();
        Debug.Log($"The active player is now: {GameMaster.Instance.getActivePlayer()}");
    }

    public void changePlayerTurn(){
        GameMaster.Instance.changePlayerTurn();
        Debug.Log($"The player turn is now: {GameMaster.Instance.getPlayerTurn()}");
    }
    #endregion
    
}
