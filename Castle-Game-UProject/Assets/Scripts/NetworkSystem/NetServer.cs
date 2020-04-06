using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace NetworkSystem{
    public class NetServer{
        
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        private Thread sThread;
        
        private TSqueue<NetPacket> _squeue = new TSqueue<NetPacket>();
        
        private string _IP;
        private int _port;

        private PrintWrapper _pw;

        private callBack cb;
        public NetServer(string IP, int PORT){
            _IP = IP;
            _port = PORT;
        }
   
        /// <summary>
        /// Set a print wrapper
        /// </summary>
        /// <param name="pw"></param>
        public void setPWrp(PrintWrapper pw){
            _pw = pw;
        }

        /// <summary>
        /// Attempt to print to the print wrapper
        /// </summary>
        /// <param name="s"></param>
        private void printS(string s){
            if (_pw != null){
                _pw.print(s);
            }
        }
        
        public void StartServer(){
            sThread = new Thread(new ThreadStart(serverThread));
            sThread.IsBackground = true;
            sThread.Start();
        }
        
        public void StartServer(callBack _cb){
            
            cb = _cb;
            sThread = new Thread(new ThreadStart(serverThread));
            sThread.IsBackground = true;
            sThread.Start();
        }

        public void CloseServer(){

        }

        public void sendString(string s){
            if (_tcpClient == null){
                return;
            }

            try{
                NetworkStream stream = _tcpClient.GetStream();
                if (stream.CanWrite){
                    byte[] messageBArr = Encoding.ASCII.GetBytes(s);
                    stream.Write(messageBArr, 0, messageBArr.Length);
                }
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }
        
        private void serverThread(){
            try{
                _tcpListener = new TcpListener(IPAddress.Any, _port);
                printS("Listening for connection...");
                _tcpListener.Start();
                _tcpClient = _tcpListener.AcceptTcpClient();
                NetworkStream stream = _tcpClient.GetStream();
                
                cb?.Invoke("Client Connected");
                
                Byte[] bytes = new byte[4];
                while (true){
                    int length;
                    if (stream.DataAvailable){
                        // Read the first 4 bytes
                        stream.Read(bytes, 0, 4);
                        length = BitConverter.ToInt32(bytes, 0);
                        printS(length.ToString());
                    }
                }
                
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }
        
        public void sendNetPacket(NetPacket np){
            if (_tcpClient == null){
                return;
            }

            try{
                NetworkStream stream = _tcpClient.GetStream();
                if (stream.CanWrite){
                    // First write the size of the packet we want to send
                    stream.Write(BitConverter.GetBytes(np.size),0,4);
                }
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }
        
    }
}