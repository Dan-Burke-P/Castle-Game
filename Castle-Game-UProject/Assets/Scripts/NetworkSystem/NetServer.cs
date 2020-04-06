using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkSystem{
    public class NetServer{
        
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        
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
            
        }

        public void CloseServer(){
            
        }

        private void serverThread(){
            try{
                _tcpListener = new TcpListener(IPAddress.Any, _port);
                printS("Listening for connection...");
                _tcpListener.Start();
                Byte[] bytes = new byte[1024];
                while (true){
                    using (_tcpClient = _tcpListener.AcceptTcpClient()){
                        using (NetworkStream stream = _tcpClient.GetStream()){
                            int length;

                            while ((length = stream.Read(bytes, 0, bytes.Length)) > 0){
                                var incomingData = new byte[length];
                                Array.Copy(bytes, 0, incomingData, 0, length);
                                string clientMessage = Encoding.ASCII.GetString(incomingData);
                                printS(clientMessage);
                                _tcpListener.Stop();
                                break;
                            }
                        }
                    }
                    break;
                }
                
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }
        
        
    }
}