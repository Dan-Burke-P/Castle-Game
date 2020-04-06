using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetworkSystem{
    public class NetServer{
        
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        private Thread sThread;
        
        private TSqueue<string> _squeue = new TSqueue<string>();
        
        private string _IP;
        private int _port;

        private PrintWrapper _pw;
        
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
                Byte[] bytes = new byte[1024];
                while (true){
                    int length;
                    while ((length = stream.Read(bytes, 0, bytes.Length)) > 0){
                        var incomingData = new byte[length];
                        Array.Copy(bytes, 0, incomingData, 0, length);
                        string clientMessage = Encoding.ASCII.GetString(incomingData);
                        printS(clientMessage);
                        _squeue.enqueue(clientMessage);
                    }
                }
                
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }

        public bool getMessage(out string msg){
            string ret;
            if (_squeue.tryDequeue(out ret)){
                printS("Found return string: " + ret);
                msg = ret;
                return true;
            }

            msg = "";
            return false;
        }
        
    }
}