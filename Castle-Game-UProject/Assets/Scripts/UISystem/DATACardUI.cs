using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="CardUI/Card Data")]
public class DATACardUI : ScriptableObject
{
    public string title;
    public int cost;
    public string cardText;

    public GameObject renderedObject;
}
