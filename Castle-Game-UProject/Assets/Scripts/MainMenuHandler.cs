using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour{

    /// <summary>
    /// The panel with the main menu options
    /// </summary>
    public GameObject mainMenu;
    
    /// <summary>
    /// Panel containing debug options
    /// </summary>
    public GameObject debugMenu;
    
    /// <summary>
    /// Panel containing network demos
    /// </summary>
    public GameObject networkDemoList;

    public GameObject playPanel;

    public GameObject optionPanel;

    private void OnEnable(){
        openMainMenu();
    }

    /// <summary>
    /// Hides all of the panels, useful to just hide everything before
    /// displaying a single panel
    /// </summary>
    public void hideAllPanels(){
        mainMenu.SetActive(false);
        debugMenu.SetActive(false);
        networkDemoList.SetActive(false);
        playPanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    /// <summary>
    /// Open the debug menu
    /// </summary>
    public void openDebugMenu(){
        hideAllPanels();
        debugMenu.SetActive(true);
    }

    /// <summary>
    /// Open the network demo list
    /// </summary>
    public void openNetworkDemoList(){
        hideAllPanels();
        networkDemoList.SetActive(true);
    }

    public void openMainMenu(){
        hideAllPanels();
        mainMenu.SetActive(true);
    }

    public void openPlayMenu(){
        hideAllPanels();
        playPanel.SetActive(true);
    }

    public void openOptionsMenu(){
        hideAllPanels();
        optionPanel.SetActive(true);
    }
    
    public void exitGame(){
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();    
        #endif
        Application.Quit();
    }
    /// <summary>
    /// Load the network message demo scene 
    /// </summary>
    public void loadNetworkMessageDemo(){
        SceneManager.LoadScene("Test/NetworkSystemTests/NetworkSystemTestScene");
    }

    public void loadTicTacDemo(){
        SceneManager.LoadScene("Test/NetworkSystemTests/TicTacNETDEMO/TicTacTestScene");
    }

}
