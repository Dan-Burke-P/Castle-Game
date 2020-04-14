using UnityEngine;

namespace GameManagers{
    public class GameMaster : MonoBehaviour{

        private int _playerTurn = 1;
        
        public PlayerManager player1;
        public PlayerManager player2;

        public gameSetup gameMode;
        public enum gameSetup{
            HOTSEAT,
            NETHOST,
            NETCLIENT,
            NETDEDICATED
        }
        
        public enum GameState
        {
            CardPhase1, 
            UnitPhase1, 
            CardPhase2, 
            UnitPhase2
        }

        public static GameState state;
    
        void Awake(){
        }

        // Start is called before the first frame update
        void Start()
        {
            state = GameState.CardPhase1;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        #region GameStartOptions

        /// <summary>
        /// Sets up a game for local multiplayer in a hot seat configuration 
        /// </summary>
        public void createHotSeatGame(){
            
            gameMode = gameSetup.HOTSEAT;
            player1.setPlayer(ScriptableObject.CreateInstance<PlayerData>());
            player1.setPlayerNumber(1);
            
            player2.setPlayer(ScriptableObject.CreateInstance<PlayerData>());
            player2.setPlayerNumber(2);
        }

        /// <summary>
        /// Sets up the game as a host 
        /// </summary>
        public void createNetHostGame(){
            
        }

        /// <summary>
        /// Sets up the game as a client
        /// </summary>
        public void createNetClientGame(){
            
        }

        /// <summary>
        /// Sets the game up connecting to a dedicated server instead of peer to peer
        /// </summary>
        public void createDedicatedClientGame(){
            
        }

        #endregion
    }
}
