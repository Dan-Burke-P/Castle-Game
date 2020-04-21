using Assets.Scripts.InputSystem;
using UnityEngine;

namespace GameManagers{
    public partial class GameMaster : MonoBehaviour{

        
        /// <summary>
        /// Used to tell other game systems if selection mode is active or not
        /// </summary>
        public bool selectionMode = true;
        
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
        [SerializeField]
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
        
        /// <summary>
        /// The phases of a turn, they progress states in descending order
        /// </summary>
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

            state = TurnPhase.PreTurn;
            
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

        public TurnPhase getGamePhase(){
            return state;
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

        /// <summary>
        /// Checks the game state and set up to determine if the active player
        /// should be allowed to input state altering data
        /// </summary>
        /// <returns></returns>
        public bool isPlayerActive(int player){
            if (player == _activePlayer){
                return true;
            }
            else{
                return false;
            }
            
            // otherwise we can return false
            return false;
        }

        /// <summary>
        /// Progresses the game to the next state
        /// </summary>
        public void progressGame(){
            
            priorityCheck(state);
            
            Debug.Log("Current phase: " + state + " Active player: " + _activePlayer + " Player Turn: " + _playerTurn);
        }

        /// <summary>
        /// Just a simple function to help us know the order of events without having to hard code in transitions
        /// </summary>
        /// <param name="p">
        /// The state we want to find the next state from
        /// </param>
        /// <returns>
        /// The state that occurs after p
        /// </returns>
        private TurnPhase nextPhase(TurnPhase p){
            switch (p){
                case TurnPhase.PreTurn:
                    return TurnPhase.Renewal;
                    break;
                case TurnPhase.Renewal:
                    return TurnPhase.MainPhase;
                    break;
                case TurnPhase.MainPhase:
                    return TurnPhase.Cleanup;
                    break;
                case TurnPhase.Cleanup:
                    return TurnPhase.PrePass;
                    break;
                case TurnPhase.PrePass:
                    return TurnPhase.PreTurn;
                    break;
            }

            return TurnPhase.PreTurn;
        }

        /// <summary>
        /// checks if the priority has been given to the opposing player before the turn passes
        /// </summary>
        /// <param name="tp">
        /// the current turn phase
        /// </param>
        private void priorityCheck(TurnPhase tp){
            if (_activePlayer == _playerTurn){
                changeActivePlayer();
            }
            else{
                changeActivePlayer();
                // Run the function for exiting this state
                runExitingStateFunction(tp);
                // Progress to the next phase
                state = nextPhase(tp);
                // Run the function for entering the new state
                runEnteringStateFunction(state);
            }
        }

        
    }
}
