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

        private TcpListener tcpLister;
        private Thread tcpListenerThread;
        private TcpClient connectedTcpClient;

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
                _initHost();
            }
            else{
                _initClient();
            }
        }

        private void _initHost(){
            pw.print("Starting as host...");
            tcpListenerThread = new Thread(new ThreadStart(listenForConnection));
            tcpListenerThread.IsBackground = true;
            tcpListenerThread.Start();
            
        } // End _initHost()

        private void listenForConnection(){
            try{
                tcpLister = new TcpListener(IPAddress.Any, port);
                pw.print("Listening for connection...");
                tcpLister.Start();
                Byte[] bytes = new byte[1024];
                while (true){
                    using (connectedTcpClient = tcpLister.AcceptTcpClient()){
                        using (NetworkStream stream = connectedTcpClient.GetStream()){
                            int length;

                            while ((length = stream.Read(bytes, 0, bytes.Length)) > 0){
                                var incomingData = new byte[length];
                                Array.Copy(bytes, 0, incomingData, 0, length);
                                string clientMessage = Encoding.ASCII.GetString(incomingData);
                                pw.print(clientMessage);
                                tcpLister.Stop();
                                break;
                            }
                        }
                    }
                    break;
                }
                
            }
            catch (SocketException e){
                pw.print(e.ToString());
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