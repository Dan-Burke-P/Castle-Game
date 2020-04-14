using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace StandAloneServer{
    public class netServer{
        
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;

        private Thread sThread;
        
        private string _IP;
        private int _port;

        public netServer(string IP, int port){
            _IP = IP;
            _port = port;
            sThread = new Thread(new ThreadStart(serverThread));
            sThread.IsBackground = true;
            sThread.Start();
        }    
        
        private void serverThread(){
            try{
                _tcpListener = new TcpListener(IPAddress.Any, _port);
                Console.WriteLine("Listening for connection...");
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
                                Console.WriteLine("Listening for connection...");
                                _tcpListener.Stop();
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            catch (SocketException e){
                Console.WriteLine("Listening for connection...");       
            }
        }
    }
}