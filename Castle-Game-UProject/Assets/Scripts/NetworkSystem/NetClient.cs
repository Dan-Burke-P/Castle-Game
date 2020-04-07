using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace NetworkSystem{
    public class NetClient{
        
        private callBack cb;
        
        private string _IP;
        private int _port;

        private TcpClient socketConnection;
        private Thread cThread;

        private TSqueue<NetPacket> _squeue = new TSqueue<NetPacket>();

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
                NetworkStream stream = socketConnection.GetStream();
                
                Byte[] bytes = new byte[16];
                while (true){
                    int length;
                    
                    // If we have data attempt to read the first 4 bytes to get the size of the whole packet we will be reading
                    if (stream.DataAvailable){
                        stream.Read(bytes, 0, 16);
                        NetPacket np = new NetPacket();
                        np.setHeaderFromBArr(bytes);
                        _squeue.enqueue(np);
                        printS(np.ToString());
                    }
                }
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }

        public void sendNetPacket(NetPacket np){
            if (socketConnection == null){
                return;
            }

            try{
                NetworkStream stream = socketConnection.GetStream();
                if (stream.CanWrite){
                    // First write the size of the packet we want to send
                    stream.Write(np.getHeaderBArr(),0,16);
                }
            }
            catch (SocketException e){
                printS(e.ToString());
            }
        }
        
        public bool getPacket(out NetPacket np){
            NetPacket ret;
            if (_squeue.tryDequeue(out ret)){
                printS("Found network packet in queue");
                np = ret;
                return true;
            }

            np = null;
            return false;
        }
        
        /*public bool getMessage(out string msg){
            string ret;
            if (_squeue.tryDequeue(out ret)){
                printS("Found return string: " + ret);
                msg = ret;
                return true;
            }

            msg = "";
            return false;
        }*/
    }
}