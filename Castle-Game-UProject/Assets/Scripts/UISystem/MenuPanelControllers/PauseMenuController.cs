using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour{

    public GameObject pauseMenu;

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
}
