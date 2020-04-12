using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUIButtons : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene()
    {
        // find all the cards and remove them
        DeckUpdateSprite[] cards = FindObjectsOfType<DeckUpdateSprite>();
        foreach (DeckUpdateSprite card in cards)
        {
            Destroy(card.gameObject);
        }
        ClearTopValues();
        // deal new cards
        FindObjectOfType<DeckFunction>().PlayCards();
    }

    void ClearTopValues()
    {
        DeckSelectable[] selectables = FindObjectsOfType<DeckSelectable>();
        foreach (DeckSelectable selectable in selectables)
        {
            if (selectable.CompareTag("Top"))
            {
                selectable.suit = null;
                selectable.value = 0;
            }
        }
    }

}
