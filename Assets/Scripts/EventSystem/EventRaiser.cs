using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser : MonoBehaviour
{
    public Event _event;

    public void Raise()
    {
        _event.raise();
    }
}
