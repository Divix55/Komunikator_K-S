using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serwer = new TcpListener(IPAddress.Parse("127.0.0.1"), 1024);

            serwer.Start();
            TcpClient newClient = serwer.AcceptTcpClient();
            TcpClient newClientA = serwer.AcceptTcpClient();
            BinaryReader reader = new BinaryReader(newClient.GetStream());
            BinaryReader readerA = new BinaryReader(newClientA.GetStream());
            Console.WriteLine("Połączenie ustanowione.");
            while(true)
            {
                Console.WriteLine(reader.ReadString());
                Console.WriteLine(readerA.ReadString());
            }
        }
    }
}
