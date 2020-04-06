using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetworkSystem{
    
    /// <summary>
    /// The basic network connection interface
    /// </summary>
    public class NetConn{

        private TcpClient socketConnection;
        private Thread clientReceiveThread;

        private NetServer _server;
        
        

        private PrintWrapper pw;
        /// <summary>
        /// Target IP we want to connect to
        /// </summary>
        private string IP;
        
        /// <summary>
        /// Target port we want to use
        /// </summary>
        private int port;

        /// <summary>
        /// What kind of connection is this?
        /// Client
        /// Host
        /// </summary>
        private mode netMode;
        
        public NetConn(PrintWrapper _PW, string _IP, int _PORT, mode _MODE){
            netMode = _MODE;
            IP = _IP;
            port = _PORT;
            pw = _PW;
            
            if (netMode == mode.HOST){
                _server = new NetServer(IP, port);
                _server.setPWrp(pw);
            }
            else{
                _initClient();
            }
        }
        
        private void _initClient(){
            try
            {
                var client = new TcpClient(IP, port);

                NetworkStream ns = client.GetStream();

                byte[] bytes = Encoding.ASCII.GetBytes("Test Message!");

                ns.Write(bytes, 0, bytes.Length);

                client.Close();

            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }

        }

        public bool endConnection(){
            return true;
        }
    }
}