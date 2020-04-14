using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace StandAloneServer{
    internal class Program{
        
        private static netServer nserver;
        
        public static void Main(string[] args){
            Console.WriteLine("Starting stand alone server...");
            nserver = new netServer("", 12345);
            while (true){
                
            }
        }

        
    }
}