using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTestDriver : MonoBehaviour
{
    public static Hand hand; // The hand that's being manipulated for this test scene

    // Start is called before the first frame update
    void Start()
    {
        hand = ScriptableObject.CreateInstance<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Adds a Create Soldier card into the test hand
    public void testAddSoldierToHand()
    {
        Dictionary<string, object> prms = new Dictionary<string, object>();
        
        Card c = ScriptableObject.CreateInstance<CRD_SU_soldier>();

        prms.Add("card", c);

        hand.addCardToHand(prms);
    }
    
	// Adds a Siege card into the test hand
    public void testAddSiegeToHand()
    {
        Dictionary<string, object> prms = new Dictionary<string, object>();
        
        Card c = ScriptableObject.CreateInstance<CRD_SU_siege>();

        prms.Add("card", c);

        hand.addCardToHand(prms);
    }

	// Removes whatever card you were just looking at
    public void testRemoveCardFromHand()
    {
        Dictionary<string, object> prms = new Dictionary<string, object>();

        prms.Add("index", hand.currentIndex);

        hand.removeCardFromHand(prms);
    }

	// View the next card in the test hand
	public void testNextButton()
	{
		Dictionary<string, object> prms = new Dictionary<string, object>();

		prms.Add("hand", hand);

		HandButtonScript.Instance().nextCard(prms);
	}

	// View the previous card in the test hand
	public void testPreviousButton()
	{
		Dictionary<string, object> prms = new Dictionary<string, object>();

		prms.Add("hand", hand);

		HandButtonScript.Instance().previousCard(prms);
	}
}
