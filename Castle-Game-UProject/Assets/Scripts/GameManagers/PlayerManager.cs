using UnityEngine;

namespace GameManagers{
    public class PlayerManager : MonoBehaviour{

    
        private PlayerData player;

        public void setPlayer(PlayerData p){
            player = p;
        }

        public void setPlayerNumber(int i){
            player.playerNumber = i;
        }
    }
}
