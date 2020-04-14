using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetworkSystem{
    
    /// <summary>
    /// Call back for the connection attempt to notify the calling user the status of the connection
    /// </summary>
    /// <param name="s">The message that will be delivered by netconn</param>
    public delegate void callBack(string s);
    
    /// <summary>
    /// The basic network connection interface
    /// </summary>
    public class NetConn{

        private TcpClient socketConnection;
        private Thread clientReceiveThread;

        private NetServer _server;
        private NetClient _client;


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
                _server.StartServer();
            }
            else{
                _client = new NetClient(IP, port);
                _client.setPWrp(pw);
                _client.startConnection();
            }
        }
        
        public NetConn( string _IP, int _PORT, mode _MODE){
            netMode = _MODE;
            IP = _IP;
            port = _PORT;

            if (netMode == mode.HOST){
                _server = new NetServer(IP, port);
                _server.setPWrp(pw);
                _server.StartServer();
            }
            else{
                _client = new NetClient(IP, port);
                _client.setPWrp(pw);
                _client.startConnection();
            }
        }
        
        public NetConn(callBack cb, string _IP, int _PORT, mode _MODE){
            netMode = _MODE;
            IP = _IP;
            port = _PORT;

            if (netMode == mode.HOST){
                _server = new NetServer(IP, port);
                _server.setPWrp(pw);
                _server.StartServer(cb);
            }
            else{
                _client = new NetClient(IP, port);
                _client.setPWrp(pw);
                _client.startConnection();
            }
        }
        
        public NetConn(PrintWrapper _PW, callBack cb, string _IP, int _PORT, mode _MODE){
            netMode = _MODE;
            IP = _IP;
            port = _PORT;
            pw = _PW;
            
            if (netMode == mode.HOST){
                _server = new NetServer(IP, port);
                _server.setPWrp(pw);
                _server.StartServer(cb);
            }
            else{
                _client = new NetClient(IP, port);
                _client.setPWrp(pw);
                _client.startConnection();
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
                pw.print(e.ToString());
            }

        }

        public void sendNetPacket(NetPacket np){
            pw.print("Sending packet stream...");

            if (netMode == mode.HOST){
                _server.sendNetPacket(np);
            }

            if (netMode == mode.CLIENT){
                _client.sendNetPacket(np);
            }
        }
        
        public bool endConnection(){
            return true;
        }
        

        public bool getNetPacket(out NetPacket np){
            bool status = false;
            if (netMode == mode.CLIENT){
                status = _client.getPacket(out np);
            }
            else{
                status = _server.getPacket(out np);
            }

            return status;
        }
    }
}