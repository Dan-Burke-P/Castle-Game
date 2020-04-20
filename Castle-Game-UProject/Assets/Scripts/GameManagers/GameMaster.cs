using Assets.Scripts.InputSystem;
using UnityEngine;

namespace GameManagers{
    public class GameMaster : MonoBehaviour{
        
        /// <summary>
        /// The id number of the local player used for denoting control flow
        /// </summary>
        private int _localPlayer = 1;
        
        /// <summary>
        /// Data used to setup the game in the proper way
        /// </summary>
        public SetupSystemData setupData;

        /// <summary>
        /// The current turn the game is on
        /// </summary>
        public int turnCount = 0;
        
        /// <summary>
        /// What player is currently taking their turn
        /// </summary>
        private int _playerTurn = 1;
        
        /// <summary>
        /// The currently active player
        /// </summary>
        private int _activePlayer = 1;
        
        /// <summary>
        /// The data for player 1, in net play this will always be the local player
        /// </summary>
        public PlayerManager player1;
        
        /// <summary>
        /// The data for player 2, in net play this will always be the remote player
        /// </summary>
        public PlayerManager player2;

        /// <summary>
        /// The board space for the game
        /// </summary>
        public BoardSpace bs;
        
        /// <summary>
        /// The game mode we are set up for
        /// </summary>

        public gameSetup gameMode;
        public enum gameSetup{
            HOTSEAT,
            NETHOST,
            NETCLIENT,
            NETDEDICATED
        }
        
        public enum TurnPhase
        {
            PreTurn, 
            Renewal, 
            MainPhase, 
            Cleanup,
            PrePass
        }

        public static TurnPhase state;
    
        
        private static GameMaster _instance;
        /// <summary>
        /// This is the static instance of this class, used to invoke the non-static methods and 
        /// maintain a single instance.
        /// </summary>
        public static GameMaster Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject t = new GameObject();
                    t.AddComponent<GameMaster>();
                    _instance = t.GetComponent<GameMaster>();
                }
                return _instance;
            }
        }
        void Awake(){
        }

        // Start is called before the first frame update
        void Start(){
            setupData = ScriptableObject.CreateInstance<SetupSystemData>();

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

        public int getActivePlayer(){
            return _activePlayer;
        }

        public int getPlayerTurn(){
            return _playerTurn;
        }

        /// <summary>
        /// Changes active player to that of the opposite player
        /// </summary>
        public void changeActivePlayer(){
            _activePlayer = _activePlayer == 1 ? 2 : 1;
        }

        /// <summary>
        /// Changes player turn to that of the other player
        /// </summary>
        public void changePlayerTurn(){
            _playerTurn = _playerTurn == 1 ? 2 : 1;
            turnCount++;
        }

        /// <summary>
        /// Checks the game state and set up to determine if the active player
        /// should be allowed to input state altering data
        /// </summary>
        /// <returns></returns>
        public bool canActiveControl(){
            if (gameMode == gameSetup.HOTSEAT){
                // If we are currently in hotseat mode then all inputs will be recognized
                // and it is up to the players to determine whose turn it actually is
                return true;
            }
            
            // if it is not hot seat we just need to check that the local player is the same as the active player
            if (_activePlayer == _localPlayer){
                return true;
            }
            
            // otherwise we can return false
            return false;
        }

        
        /// <summary>
        /// Progresses the game to the next state
        /// </summary>
        public void progressGame(){
            switch (state){
                case GameState.CardPhase1:
                    
                    break;
                case GameState.CardPhase2:
                    break;
            }
        }

        public void ProgressState(){
            changePlayerTurn();
        }
    }
}
