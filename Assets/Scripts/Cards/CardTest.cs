using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest : MonoBehaviour
{
    public Card soldierTest;

    public Card siegeTest;

    public Hand testHand;

    public void testAddSoldier()
    {
        soldierTest = ScriptableObject.CreateInstance<CRD_SU_soldier>();
        testHand.addCardToHand(soldierTest);
    }

    public void testAddSiege()
    {
        siegeTest = ScriptableObject.CreateInstance<CRD_SU_siege>();
        testHand.addCardToHand(siegeTest);
    }

    public void testPlaySoldier()
    {
        soldierTest.play();
    }

    public void testPlaySiege()
    {
        siegeTest.play();
    }
}
