using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetworkSystem{
    public class NetPacket{

        public int size = 4;
        public int data = -1;

        /// <summary>
        /// Convert the data stored in the network packet into
        /// a serialized byte array for transport over TCP
        /// </summary>
        /// <returns>
        /// The data as a byte array
        /// </returns>
        public byte[] getAsByteArr(){

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream mStrm = new MemoryStream();
            
            bf.Serialize(mStrm, data);
            byte[] ret = mStrm.ToArray();
            return ret;
        }

        public byte[] getPacketSize(){
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream mStrm = new MemoryStream();
            
            bf.Serialize(mStrm, size);
            return mStrm.ToArray();
        }
        
        
    }
}