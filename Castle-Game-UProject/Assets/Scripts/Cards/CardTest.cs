using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardTest : MonoBehaviour
{
    public Card soldierTest;

    public Card siegeTest;

    public Hand testHand;

    private UnityAction<string, object> ua;
    //public EventListener el;

    private void Start()
    {
        //el.registerAction(testPrint);
    }

    public void testAddSoldier()
    {
        //soldierTest = ScriptableObject.CreateInstance<CRD_SU_soldier>();
        //testHand.addCardToHand(soldierTest);
    }

    public void testAddSiege()
    {
        siegeTest = ScriptableObject.CreateInstance<CRD_SU_siege>();
        //testHand.addCardToHand(siegeTest);
    }

    public void testPlaySoldier()
    {
        soldierTest.play();
    }

    public void testPlaySiege()
    {
        siegeTest.play();
    }

    private void testPrint(Dictionary<string, object> o)
    {
        Debug.Log("Test Print");
    }
}
