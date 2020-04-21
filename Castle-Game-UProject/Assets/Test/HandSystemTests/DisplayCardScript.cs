using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is tied to a specific hand in HandTestDriver. May need to refactor this for the actual game
public class DisplayCardScript : MonoBehaviour
{
    public Text cardInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        cardInfo = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        displayCard();
    }

    // Always show data on one of the cards in your hand
    public void displayCard()
    {
        // Check if the test hand is empty
        if(HandTestDriver.hand.currentIndex != -1) {
            cardInfo.text = "Card Name: " + HandTestDriver.hand.cards[HandTestDriver.hand.currentIndex].cardTitle;
        }
        else {
            cardInfo.text = "No card selected";
        }
    }
}
