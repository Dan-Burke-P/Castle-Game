using System.Collections;
using System.Collections.Generic;
using GameManagers;
using UnityEngine;
using UnityEngine.UI;

// This script is tied to a specific hand in HandTestDriver. May need to refactor this for the actual game
public class GameStateDisplayScript : MonoBehaviour
{
    public Text gameState;
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		displayGameState();
    }

	// Display the current game state
	public void displayGameState() 
	{
		switch ((int) GameMaster.state)
		{
			case 0:
				gameState.text = "Player 1 is selecting cards";
				break;
			case 1:
				gameState.text = "Player 1 is moving units";
				break;
			case 2:
				gameState.text = "Player 2 is selecting cards";
				break;
			case 3:
				gameState.text = "Player 2 is moving units";
				break;
		}
	}
}
