using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory
{

    public static BaseCard createCard<CardClass>() where CardClass : BaseCard{
        CardClass card = ScriptableObject.CreateInstance<CardClass>();

        return card;
    }
}

