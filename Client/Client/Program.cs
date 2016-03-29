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
            string serwer, wiadomosc;
            Console.WriteLine("Podaj adres ip serwera: ");
            serwer = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Napisz coś: ");
                wiadomosc = Console.ReadLine();
                polaczenie(serwer,wiadomosc);
            }
        }

        static void polaczenie(string serwer, string wiadomosc)
        {
            try
            {
                Int32 port = 1024;
                TcpClient klient = new TcpClient(serwer, port);

                Byte[] dane = System.Text.Encoding.ASCII.GetBytes(wiadomosc);

                NetworkStream stream = klient.GetStream();

                stream.Write(dane, 0, dane.Length);

                Console.WriteLine("Wyślij: {0}", wiadomosc);

                dane = new Byte[256];

                string nowedane = string.Empty;

                Int32 bajt = stream.Read(dane, 0, dane.Length);
                nowedane = System.Text.Encoding.ASCII.GetString(dane, 0, bajt);
                Console.WriteLine("Otrzymano: {0}", nowedane);

                stream.Close();
                klient.Close();
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            
        }
    }
}
