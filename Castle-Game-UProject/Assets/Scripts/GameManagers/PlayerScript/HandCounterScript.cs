using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is tied to a specific hand in HandTestDriver. May need to refactor this for the actual game
public class HandCounterScript : MonoBehaviour
{
    public Text handCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        handCounter = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		displayHandCounter();
    }

	// Always display which card in your hand you are looking at
	public void displayHandCounter() 
	{
		// If hand is not empty, set text equal to "Card x of y" to keep track of which card you are looking at
		if(HandTestDriver.hand.cards.Count > 0) {
			handCounter.text = "Card " + (HandTestDriver.hand.currentIndex + 1) + " of " + HandTestDriver.hand.cards.Count;
		}
		else {
			handCounter.text = "Your hand is empty.";
		}
	}
}
