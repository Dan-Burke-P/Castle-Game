using System.Collections;
using System.Collections.Generic;
using GameManagers;
using UnityEngine;

public class GameStateControlsHandler : MonoBehaviour
{
    public void passTurn(){
        GameMaster.Instance.progressGame();
    }
}
