using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour{

    public GameObject mainMenu;
    public GameObject debugMenu;



    public void openDebugMenu(){
        mainMenu.SetActive(false);
        debugMenu.SetActive(true);
    }

    public void loadNetworkTestScene(){
        SceneManager.LoadScene("Test/NetworkSystemTests/NetworkSystemTestScene");
    }

}
