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
            // Hide the pressed numbers sprite
            sprites[num].SetActive(false);

            board[num - 1] = pieceType.XPIECE;
            
            updateBoardUI();
            
            checkWin();
        }
        
        public void play(int pos){
            
        }

        public void updateBoardUI(){
            for (int i = 0; i < board.Length; i++){
                if (board[i] == pieceType.XPIECE && !boardSet[i]){
                    
                    GameObject tmp = Instantiate(XP_GO);
                    tmp.transform.position = pieceSlots[i];
                    boardSet[i] = true;

                }else if (board[i] == pieceType.OPIECE){
                    
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
            return board[i] == board[j] && board[i] == board[j];
        }
        
        public void becomeHost(){
            connectionsPanel.SetActive(false);
            nc = new NetConn(pw, onConnectCB,"localhost", 12345, mode.HOST);
            hostStatus.gameObject.SetActive(true);
            hostStatus.text = "Waiting for connection...";
        }

        public void becomeClient(){
            connectionsPanel.SetActive(false);
            nc = new NetConn(onConnectCB,"localhost", 12345, mode.CLIENT);
            hostStatus.gameObject.SetActive(true);
            hostStatus.text = "Attempting to connect...";
        }

        public void onConnectCB(string s){
            Debug.Log(s);
            hostStatus.text = s;
        }


        private void Update(){
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

