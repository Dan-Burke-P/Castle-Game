using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseCard
{
    int cost { get; set; }
    CardType type { get; set; }

    // Play the card 
    void play();
}
