using System;
using UnityEngine;

namespace GameManagers{
    public class SetupSystemData : ScriptableObject{
        public GameMaster.gameSetup gameMode;
        public string IP;
        public int port;
        public void OnEnable(){
            gameMode = (GameMaster.gameSetup)PlayerPrefs.GetInt("GameMode");
            IP = PlayerPrefs.GetString("IP");
            port = PlayerPrefs.GetInt("port");
        }

        public void OnDisable(){
            PlayerPrefs.SetInt("GameMode", (int)gameMode);
            PlayerPrefs.SetInt("port", port);
            PlayerPrefs.SetString("IP", IP);
        }
    }
}
