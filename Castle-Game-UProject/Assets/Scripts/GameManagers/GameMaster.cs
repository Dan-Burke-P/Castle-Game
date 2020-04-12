using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public enum GameState
    {
        CardPhase1, 
        UnitPhase1, 
        CardPhase2, 
        UnitPhase2
    }

    public static GameState state;
    
    void Awake(){
        // First thing we do is register all of the event types we will be using
        //EventInitializer.initEvents();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.CardPhase1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
