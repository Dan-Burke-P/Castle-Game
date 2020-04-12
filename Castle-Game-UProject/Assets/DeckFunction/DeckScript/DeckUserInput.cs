using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckUserInput : MonoBehaviour
{
    public GameObject slot1;
    private DeckFunction DeckFunct;
    private float timer;
    private float doubleClickTime = 0.3f;
    private int clickCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        DeckFunct = FindObjectOfType<DeckFunction>();
        slot1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickCount == 1)
        {
            timer += Time.deltaTime;
        }
        if (clickCount == 3)
        {
            timer = 0;
            clickCount = 1;
        }
        if (timer > doubleClickTime)
        {
            timer = 0;
            clickCount = 0;
        }

        GetMouseClick();
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                // what has been hit? Deck/Card/EmptySlot...
                if (hit.collider.CompareTag("Deck"))
                {
                    //clicked deck
                    Deck();
                }
                else if (hit.collider.CompareTag("Card"))
                {
                    // clicked card
                    Card(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Top"))
                {
                    // clicked top
                    Top(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Bottom"))
                {
                    // clicked bottom
                    Bottom(hit.collider.gameObject);
                }
            }
        }
    }

    void Deck()
    {
        // deck click actions
        print("Clicked on deck");
        DeckFunct.DealFromDeck();
        slot1 = this.gameObject;

    }
    void Card(GameObject selected)
    {
        // card click actions
        print("Clicked on Card");

        if (!selected.GetComponent<DeckSelectable>().faceUp) // if the card clicked on is facedown
        {
            
            
                // flip it over
                selected.GetComponent<DeckSelectable>().faceUp = true;
                slot1 = this.gameObject;
            

        }
        else if (selected.GetComponent<DeckSelectable>().inDeckPile) // if the card clicked on is in the deck pile with the trips
        {
            
               
                    slot1 = selected;
                }                
            

        
        else
        {

            // if the card is face up
            // if there is no card currently selected
            // select the card

            if (slot1 == this.gameObject) // not null because we pass in this gameObject instead
            {
                slot1 = selected;
            }

            // if there is already a card selected (and it is not the same card)
            else if (slot1 != selected)
            {
               
                    slot1 = selected;
                
            }

            else if (slot1 == selected) // if the same card is clicked twice
            {
                if (DoubleClick())
                {
                slot1 = selected;
                    //AutoStack(selected);
                }
            }


        }
    }
   
   
    void Top(GameObject selected)
    {
        // top click actions
        print("Clicked on Top");
        if (slot1.CompareTag("card"))
        {
            // if  empty slot is top then stack
            if (slot1.GetComponent<DeckSelectable>().value == 1)
            {
                Stack(selected);
            }

        }


    }
    void Bottom(GameObject selected)
    {
        // bottom click actions
        print("Clicked on Bottom");
        // if there is an empty slot, card bottom then stack

        if (slot1.CompareTag("Card"))
        {
            if (slot1.GetComponent<DeckSelectable>().value != 0)
            {
                Stack(selected);
            }
        }



    }
    

    

    void Stack(GameObject selected)
    {
        // if empty bottom stack the cards in place
        // else stack the cards with a negative y offset

        DeckSelectable s1 = slot1.GetComponent<DeckSelectable>();
        DeckSelectable s2 = selected.GetComponent<DeckSelectable>();
        float yOffset = 0;

        

        slot1.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y - yOffset, selected.transform.position.z - 0.01f);
        slot1.transform.parent = selected.transform; // this makes the children move with the parents

        if (s1.inDeckPile) // removes the cards from the top pile to prevent duplicate cards
        {
            DeckFunct.tripsOnDisplay.Remove(slot1.name);
        }
        
        else if (s1.top) // keeps track of the current value of the top decks as a card has been removed
        {
            DeckFunct.topPos[s1.row].GetComponent<DeckSelectable>().value = s1.value - 1;
        }
        else // removes the card string from the appropriate bottom list
        {
            DeckFunct.bottoms[s1.row].Remove(slot1.name);
        }

        s1.inDeckPile = false; // you cannot add cards to the trips pile so this is always fine
        s1.row = s2.row;

        

    }

    void AutoStack(GameObject selected)
    {}

    bool DoubleClick()
    {
        if (timer < doubleClickTime && clickCount == 2)
        {
            print("Double Click");
            return true;
        }
        else
        {
            return false;
        }
    }

    

}
