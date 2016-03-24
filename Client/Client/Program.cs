using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string nazwa;
            TcpClient klient = new TcpClient();
            klient.Connect("127.0.0.1", 1024);

            BinaryWriter writer = new BinaryWriter(klient.GetStream());
            Console.WriteLine("Witaj! Jak się nazywasz? ");
            nazwa = Console.ReadLine();
            Console.WriteLine("Napisz coś do serwera: ");
            while(true)
            {
                writer.Write(nazwa + ": " + Console.ReadLine());
            }
        }
    }
}
