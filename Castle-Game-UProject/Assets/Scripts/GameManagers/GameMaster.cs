using UnityEngine;

namespace GameManagers{
    public class GameMaster : MonoBehaviour{

        public SetupSystemData setupData;
         
        private int _playerTurn = 1;
        private int _activePlayer = 1;
        public PlayerManager player1;
        public PlayerManager player2;

        public BoardSpace bs;
        
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
        }
    }
}
