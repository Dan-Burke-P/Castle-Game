using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/Card")]
public abstract class Card : ScriptableObject
{
    public string title { get; set; }
    public CardType type { get; set; }
    
    public GameObject renderedObject;

    public abstract void play();

}
