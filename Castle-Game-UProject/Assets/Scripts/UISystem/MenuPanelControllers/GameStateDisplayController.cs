using System;
using System.Collections;
using System.Collections.Generic;
using GameManagers;
using UnityEngine;
using UnityEngine.UI;

public class GameStateDisplayController : MonoBehaviour{
    public Text playerTurn;
    public Text activePlayer;
    public Text gamePhase;
    public Text turnCount;

    public int debug;
    private void Update(){

        debug = GameMaster.Instance.getPlayerTurn();
        playerTurn.text   = $"Players Turn: {GameMaster.Instance.getPlayerTurn()}";
        activePlayer.text = $"Active Player: {GameMaster.Instance.getActivePlayer()}";
        gamePhase.text    = $"Game Phase: {GameMaster.Instance.getGamePhase()}";
        turnCount.text    = $"Turn Count: {GameMaster.Instance.turnCount}";
    }
}
