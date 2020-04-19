using System;
using System.Collections;
using System.Collections.Generic;
using GameManagers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuButtons : MonoBehaviour{

    private SetupSystemData ssd;

    private void Awake(){
        ssd = ScriptableObject.CreateInstance<SetupSystemData>();
    }

    public void joinGame(){
        Debug.LogError("Feature not implemented");
        Debug.Log("Starting game in local multiplayer mode");
        ssd.gameMode = GameMaster.gameSetup.NETCLIENT;
        SceneManager.LoadScene("PlayScene");
    }

    public void hostGame(){
        Debug.LogError("Feature not implemented");
        Debug.Log("Starting game in local multiplayer mode");
        ssd.gameMode = GameMaster.gameSetup.NETHOST;
        SceneManager.LoadScene("PlayScene");
    }

    public void localGame(){
        Debug.Log("Starting game in local multiplayer mode");
        ssd.gameMode = GameMaster.gameSetup.HOTSEAT;
        SceneManager.LoadScene("PlayScene");
    }
}
