using System;
using System.Collections.Generic;
using NetworkSystem;
using UnityEngine;
using UnityEngine.UI;

namespace NetworkSystemTests.TicTacNETDEMO{
    public class TicTacTestGM : MonoBehaviour{

        public GameObject XP_GO, OP_GO;

        public GameObject[] sprites;

        public Dictionary<int, Vector3> pieceSlots = new Dictionary<int, Vector3>{
            {0,new Vector3(-0.7f, -1.9f, 0)},
            {1,new Vector3( 0.5f, -1.9f, 0)},
            {2,new Vector3( 1.7f, -1.9f, 0)},
            {3,new Vector3(-0.7f, -0.7f, 0)},
            {4,new Vector3( 0.5f, -0.7f, 0)},
            {5,new Vector3( 1.7f, -0.7f, 0)},
            {6,new Vector3(-0.7f,  0.5f, 0)},
            {7,new Vector3( 0.5f,  0.5f, 0)},
            {8,new Vector3( 1.7f,  0.5f, 0)},
        };
        
        public enum pieceType{
            XPIECE,
            OPIECE,
            EMPTY
        }
        
        public PrintWrapper pw;
        
        public Text hostStatus;

        public GameObject connectionsPanel;

        public Transform crossBar;
        
        
        private NetConn nc;

        /// <summary>
        /// We will slice player 1 and 2 apart by who is host and who is client
        /// </summary>
        private bool isHostTurn = true;

        private bool isHost;

        private pieceType playerType;
        private pieceType enemyType;
        
        /// <summary>
        /// This is the array that will virtualize the board, the visualization below
        /// show how this lines up to the actual grid
        /// </summary>
        private pieceType[] board = new pieceType[9];
        
        private bool[] boardSet = new bool[9];
        /*
         Game board relation to array
         add one to these to get the board readout
         
                  6 | 7 | 8
                  ---------
                  3 | 4 | 5
                  ---------
                  0 | 1 | 2
         */

        private void OnEnable(){
            _resetBoard();
            
        }

        private void _resetBoard(){
            for (int i = 0; i < board.Length; i++){
                board[i] = pieceType.EMPTY;
                boardSet[i] = false;
            }

            for (int i = 0; i < sprites.Length; i++){
                sprites[i].SetActive(true);
            }
        }

        public void input(int num){
            if (isHost && isHostTurn){
                // If you are the host and it is your turn
                play(num);
            }

            if (!isHost && !isHostTurn){
                // If you are not the host and it is not host turn its your turn
                play(num);
            }
            
        }

        public void playNet(NetPacket _np){
            
            int pos = _np._header.placeHolder1;
            // Hide the pressed numbers sprite
            Debug.LogError($"Net player has taken their turn: {pos}");
            sprites[pos].SetActive(false);
            
            board[pos - 1] = enemyType;
          
            updateBoardUI();
            
            checkWin();
            
            // We have done the client side stuff now it is time to send a network message
            
            isHostTurn = !isHostTurn;
            
            
        }
        public void play(int pos){
            // Hide the pressed numbers sprite
            sprites[pos].SetActive(false);
            Debug.LogError($"Player Play Pos: {pos}");
            board[pos - 1] = playerType;
            
            updateBoardUI();
            
            checkWin();
            
            // We have done the client side stuff now it is time to send a network message
            NetPacket np = new NetPacket();
            np._header = new NetPacket.header();
            np._header.size = 4;
            np._header.placeHolder1 = pos;
            np._header.placeHolder2 = pos;
            np._header.placeHolder3 = pos;
            nc.sendNetPacket(np);
            
            isHostTurn = !isHostTurn;
        }

        public void updateBoardUI(){
            for (int i = 0; i < board.Length; i++){
                if (board[i] == pieceType.XPIECE && !boardSet[i]){
                    
                    GameObject tmp = Instantiate(XP_GO);
                    tmp.transform.position = pieceSlots[i];
                    boardSet[i] = true;

                }
                
                if (board[i] == pieceType.OPIECE && !boardSet[i]){
                    GameObject tmp = Instantiate(OP_GO);
                    tmp.transform.position = pieceSlots[i];
                    boardSet[i] = true;
                }
            }
        }

        public pieceType checkWin(){
            for (int i = 0; i < 3; i++){
                int horzBase = i * 3;
                if (checkThreeMatch(horzBase, horzBase + 1, horzBase + 2)){
                    crossBar.position = pieceSlots[horzBase + 1];
                    crossBar.Rotate(Vector3.back, 90f);
                    if (board[horzBase] == pieceType.XPIECE){
                        Debug.Log("The cross player wins!");
                        return pieceType.XPIECE;
                    }
                    else{
                        Debug.Log("The Naughts player wins!");
                        return pieceType.OPIECE;
                    }
                }

                if (checkThreeMatch(i, i + 3, i + 6)){
                    crossBar.position = pieceSlots[horzBase + 3];
                    if (board[i] == pieceType.XPIECE){
                        Debug.Log("The cross player wins!");
                        return pieceType.XPIECE;
                    }
                    else{
                        Debug.Log("The Naughts player wins!");
                        return pieceType.OPIECE;
                    }
                }
            }

            if (checkThreeMatch(0, 4, 8)){
                crossBar.position = pieceSlots[4];
                crossBar.Rotate(Vector3.back, 45f);
                if (board[0] == pieceType.XPIECE){
                    Debug.Log("The cross player wins!");
                    return pieceType.XPIECE;
                }
                else{
                    Debug.Log("The Naughts player wins!");
                    return pieceType.OPIECE;
                }
            }
            
            if (checkThreeMatch(2, 4, 6)){
                crossBar.position = pieceSlots[4];
                crossBar.Rotate(Vector3.back, -45f);
                if (board[2] == pieceType.XPIECE){
                    Debug.Log("The cross player wins!");
                    return pieceType.XPIECE;
                }
                else{
                    Debug.Log("The Naughts player wins!");
                    return pieceType.OPIECE;
                }
            }

            return pieceType.EMPTY;
        }

        /// <summary>
        /// Given 3 indices check if they all match and return the result
        /// </summary>
        /// <returns></returns>
        public bool checkThreeMatch(int i, int j, int k){
            
            // Make sure we don't go out of bounds
            if (i > 8 || j > 8 || k > 8){
                return false;
            }
            // If any of the questioned slots are empty there is no possible match
            if (board[i] == pieceType.EMPTY || board[j] == pieceType.EMPTY || board[k] == pieceType.EMPTY){
                return false;
            }
            // if the first equals the second and third then they are all equal
            return board[i] == board[j] && board[i] == board[k];
        }
        
        public void becomeHost(){
            connectionsPanel.SetActive(false);
            nc = new NetConn(pw, onConnectCB,"localhost", 12345, mode.HOST);
            hostStatus.gameObject.SetActive(true);
            hostStatus.text = "Waiting for connection...";
            isHost = true;
            playerType = pieceType.XPIECE;
            enemyType = pieceType.OPIECE;
        }

        public void becomeClient(){
            connectionsPanel.SetActive(false);
            nc = new NetConn(pw ,onConnectCB,"localhost", 12345, mode.CLIENT);
            hostStatus.gameObject.SetActive(true);
            hostStatus.text = "Attempting to connect...";
            isHost = false;
            playerType = pieceType.OPIECE;
            enemyType = pieceType.XPIECE;
        }

        public void onConnectCB(string s){
            Debug.Log(s);
        }


        private void Update(){

            if (nc != null){
                NetPacket tmp;
                if (nc.getNetPacket(out tmp)){
                    playNet(tmp);
                }
            }
            // Horrible way of handling it but this is just a demo so it is not 
            // important how ugly and dumb this code is
            if (Input.GetKeyDown(KeyCode.Keypad0)){
                input(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad1)){
                input(1);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2)){
                input(2);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3)){
                input(3);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4)){
                input(4);
            }
            if (Input.GetKeyDown(KeyCode.Keypad5)){
                input(5);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6)){
                input(6);
            }
            if (Input.GetKeyDown(KeyCode.Keypad7)){
                input(7);
            }
            if (Input.GetKeyDown(KeyCode.Keypad8)){
                input(8);
            }
            if (Input.GetKeyDown(KeyCode.Keypad9)){
                input(9);
            }
        }
    }    
}

