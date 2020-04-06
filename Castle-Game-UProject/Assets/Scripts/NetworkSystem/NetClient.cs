using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetworkSystem{
    public class NetClient{
        
        private callBack cb;
        
        private string _IP;
        private int _port;

        private TcpClient socketConnection;
        private Thread cThread;

        private TSqueue<string> _squeue = new TSqueue<string>();

        private PrintWrapper _pw;
        
        public NetClient(string IP, int PORT){
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
        
        public void startConnection(){
            try{
                cThread = new Thread(new ThreadStart(clientThread));
                cThread.IsBackground = true;
                cThread.Start();
            }
            catch (Exception e){
                printS(e.ToString());
            }
        }
        
        public void startConnection(callBack _cb){
            try{
                cb = _cb;
                cThread = new Thread(new ThreadStart(clientThread));
                cThread.IsBackground = true;
                cThread.Start();
            }
            catch (Exception e){
                printS(e.ToString());
            }
        }

        public void stopConnection(){
            
        }
        
        private void clientThread(){
            try{
                socketConnection = new TcpClient("localhost", _port);
                cb?.Invoke("Connected to host");
                Byte[] bytes = new byte[1024];
                while (true){
                    using (NetworkStream stream = socketConnection.GetStream()){
                        int length;
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0){
                            var incommingData = new byte[length];
                            Array.Copy(bytes, 0, incommingData, 0, length);
                            string serverMessage = Encoding.ASCII.GetString(incommingData);
                            printS(serverMessage);
                            _squeue.enqueue(serverMessage);
                        }
                    }
                }
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }

        public void sendMessage(string s){
            if (socketConnection == null){
                return;
            }

            try{
                NetworkStream stream = socketConnection.GetStream();
                if (stream.CanWrite){
                    byte[] messageBArr = Encoding.ASCII.GetBytes(s);
                    stream.Write(messageBArr, 0, messageBArr.Length);
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