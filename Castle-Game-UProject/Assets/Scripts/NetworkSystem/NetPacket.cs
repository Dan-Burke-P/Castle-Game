using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetworkSystem{
    public class NetPacket{

        public struct header{
            public int size;
            public int placeHolder1;
            public int placeHolder2;
            public int placeHolder3;
        }
        
        public List<NetCommand> cList = new List<NetCommand>();

        public header _header = new header();

        public string data;


        /// <summary>
        /// Gets the header with all of the details about the packet that is going to be sent
        /// Currently the header will contain 16 bytes, once the usage of them is decided they
        /// will be documented
        /// </summary>
        /// <returns>
        /// Byte array of the header for the packet
        /// </returns>
        public byte[] getHeaderBArr(){

            MemoryStream mStrm = new MemoryStream();
            
            mStrm.Write(BitConverter.GetBytes(_header.size), 0, 4);
            mStrm.Write(BitConverter.GetBytes(_header.placeHolder1), 0, 4);
            mStrm.Write(BitConverter.GetBytes(_header.placeHolder2), 0, 4);
            mStrm.Write(BitConverter.GetBytes(_header.placeHolder3), 0, 4);

            return mStrm.ToArray();
        }

        public byte[] getCListBArr(){
            MemoryStream mStrm = new MemoryStream();

            foreach (NetCommand cmd in cList){
                mStrm.Write(cmd.getCmdBArr(),0,cmd.commandSize);
            }

            Byte[] ret = mStrm.ToArray();
            mStrm.Dispose();
            return ret;
        }

        public void setHeaderFromBArr(byte[] arr){

            _header.size = BitConverter.ToInt32(arr, 0);
            _header.placeHolder1 = BitConverter.ToInt32(arr, 4);
            _header.placeHolder2 = BitConverter.ToInt32(arr, 8);
            _header.placeHolder3 = BitConverter.ToInt32(arr, 12);
        }
        
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
            
            bf.Serialize(mStrm, _header.size);
            return mStrm.ToArray();
        }

        public void addCommand(NetCommand nc){
            cList.Add(nc);
        }

        public override string ToString(){
            return $"Packet Size: {_header.size} PlaceHolder1: {_header.placeHolder1} PlaceHolder2: {_header.placeHolder2} PlaceHolder3: {_header.placeHolder3}";
        }
    }
}