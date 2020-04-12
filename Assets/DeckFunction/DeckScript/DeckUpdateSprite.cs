using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private DeckSelectable selectable;
    private DeckFunction DeckFunct;
    private DeckUserInput userInput;



    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = DeckFunction.GenerateDeck();
        DeckFunct = FindObjectOfType<DeckFunction>();
        userInput = FindObjectOfType<DeckUserInput>();

        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = DeckFunct.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<DeckSelectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }

        if (userInput.slot1)
        {

            if (name == userInput.slot1.name)
            {
                spriteRenderer.color = Color.yellow;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }
    }
}
