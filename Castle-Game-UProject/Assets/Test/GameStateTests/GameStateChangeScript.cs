/*
using System;
using System.Collections;
using System.Collections.Generic;
using GameManagers;
using UnityEngine;

public class GameStateChangeScript : MonoBehaviour
{
    private static GameStateChangeScript _instance; // Singleton design pattern
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Expecting param "state", an int representing the state of the game
    public void changeGameState(Dictionary<string, object> varg)
    {
        object obj;
        if(!varg.TryGetValue("state", out obj))
        {
            throw new ApplicationException("Raised change game state function without a state field");    
        }
        if (!(obj is int))
        {
            throw new ApplicationException("State field in change game state function was not an int");
        }

        int state = (int) obj;

        if (state < Enum.GetNames(typeof(GameMaster.GameState)).Length)
        {
            GameMaster.state = (GameMaster.GameState) state;
        }
        else
        {
            if ((int) GameMaster.state < Enum.GetNames(typeof(GameMaster.GameState)).Length - 1)
            {
                GameMaster.state++;
            }
            else
            {
                GameMaster.state = 0;
            }
        }
    }

    // Make sure there's only one instance of this class
    public static GameStateChangeScript Instance() {
        if (_instance == null)
        {
            GameObject go = new GameObject(); // Can probably be tied to an existing game object
            _instance = go.AddComponent<GameStateChangeScript>();
        }

        return _instance;
    }
}
*/
