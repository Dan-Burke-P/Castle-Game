using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour{

    public GameObject pauseMenu;

    public PromptObjectController poc;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            openPauseMenu();       
        }
    }

    public void exitPauseMode(){
        hidePanels();
    }

    public void hidePanels(){
        pauseMenu.SetActive(false);    
    }
    
    public void openPauseMenu(){
        hidePanels();
        pauseMenu.SetActive(true);
    }

    // These are a collection of end point functions for buttons //

    public void buttonExitGame(){
        poc.getResponse(exitGame, doNotExitGame, "Are you sure you want to exit to desktop?");
    }

    public void exitGame(){
        Debug.Log("Exit game confirmed");
    }

    public void doNotExitGame(){
        Debug.Log("Not exiting game");
    }
}
