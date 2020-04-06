using System;
using System.Collections.Generic;
using NetworkSystem;
using UnityEngine;
using UnityEngine.UI;

namespace NetworkSystemTests.TicTacNETDEMO{
    public class TicTacTestGM : MonoBehaviour{


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
            YPIECE,
            EMPTY
        }
        
        public PrintWrapper pw;
        
        public Text hostStatus;

        public GameObject connectionsPanel;

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
            }

            for (int i = 0; i < sprites.Length; i++){
                sprites[i].SetActive(true);
            }
        }

        public void input(int num){
            Debug.Log($"Input detected as: {num}");
            // Hide the pressed numbers sprite
            sprites[num].SetActive(false);
        }
        
        public void play(int pos){
            
        }

        public void updateBoardUI(){
            for (int i = 0; i < board.Length; i++){
                if (board[i] == pieceType.XPIECE){
                    
                }
                board[i] = pieceType.EMPTY;
            }
        }

        public void checkWin(){
            
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

