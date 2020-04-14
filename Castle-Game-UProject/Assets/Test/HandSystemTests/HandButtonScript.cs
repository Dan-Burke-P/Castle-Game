using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandButtonScript : MonoBehaviour
{
    private static HandButtonScript _instance; // Singleton design pattern
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Expecting param "hand", which contains a Hand object
    public void nextCard(Dictionary<string, object> varg)
    {
        object obj;
        if(!varg.TryGetValue("hand", out obj))
        {
            throw new ApplicationException("Raised next card function without a hand field");    
        }
        if (!(obj is Hand))
        {
            throw new ApplicationException("Hand field in next card function was not a hand");
        }

        Hand hand = obj as Hand;
        
        // Function only works if the hand is not empty
        if (hand.currentIndex != -1)
        {
            // View the next card in the list, or view the first card if you're at the end
            if (hand.currentIndex != hand.cards.Count - 1)
            {
                hand.currentIndex++;
            }
            else
            {
                hand.currentIndex = 0;
            }
        }
    }

    //Expecting param "hand", which contains a Hand object
    public void previousCard(Dictionary<string, object> varg)
    {
        object obj;
        if(!varg.TryGetValue("hand", out obj))
        {
            throw new ApplicationException("Raised previous card function without a hand field");    
        }
        if (!(obj is Hand))
        {
            throw new ApplicationException("Hand field in previous card function was not a hand");
        }

        Hand hand = obj as Hand;
        
        // Function only works if the hand is not empty
        if (hand.currentIndex != -1)
        {
            // View the previous card in the list, or view the last card if you're at the beginning
            if (hand.currentIndex != 0)
            {
                hand.currentIndex--;
            }
            else
            {
                hand.currentIndex = hand.cards.Count - 1;
            }
        }
    }
    
    // Make sure there's only one instance of this class
    public static HandButtonScript Instance() {
        if (_instance == null)
        {
            GameObject go = new GameObject(); // Can probably be tied to an existing game object
            _instance = go.AddComponent<HandButtonScript>();
        }

        return _instance;
    }
}
