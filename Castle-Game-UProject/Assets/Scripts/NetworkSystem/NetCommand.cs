using System;
using System.IO;

namespace NetworkSystem{
    
    /// <summary>
    /// Interface for commands to go in, holds data relating to
    /// the flags of the command as well as chaining of commands in a packet
    /// </summary>
    public class NetCommand{
        public int commandType;
        public int commandSize;
        public bool lastCommand;


        public Byte[] getCmdBArr(){
            MemoryStream mStrm = new MemoryStream();
            
            mStrm.Write(BitConverter.GetBytes(commandSize), 0, 4);
            mStrm.Write(BitConverter.GetBytes(commandType), 0, 4);
            mStrm.WriteByte(BitConverter.GetBytes(lastCommand)[0]);
            
            Byte[] ret = mStrm.ToArray();
            mStrm.Dispose();

            return ret;
        }
    }
}