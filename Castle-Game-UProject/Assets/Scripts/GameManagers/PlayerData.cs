using System;
using UnityEngine;

namespace GameManagers{
    public class PlayerData : ScriptableObject{

        /// <summary>
        /// ID number of the player
        /// </summary>
        public int playerNumber;

        /// <summary>
        /// Username of the player
        /// </summary>
        public string userName;

        /// <summary>
        /// The players current hand of cards
        /// </summary>
        public Hand playerHand;

        /// <summary>
        /// This players deck of cards
        /// </summary>
        public Deck playerDeck;

        public int goldRes = 0;
        
        private void OnEnable(){
            Debug.Log("Creating new player");
        }
        
    }
}
