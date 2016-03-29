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
            TcpListener serwer = null;

            try
            {
                Int32 port = 1024;
                //IPAddress adreslokalny = IPAddress.Parse("127.0.0.1");
                IPAddress adreslokalny = null;
                string adres = null;
                Console.WriteLine("Podaj adres na którym mam nasłuchiwać, lub zostaw pusto: ");
                adres = Console.ReadLine();
                if (adres == null)
                {
                    adreslokalny = IPAddress.Parse("127.0.0.1");
                }
                else
                    adreslokalny = IPAddress.Parse(adres);

                serwer = new TcpListener(adreslokalny, port);
                serwer.Start();

                Byte[] bajt = new Byte[256];
                String dane = null;

                while(true)
                {
                    Console.Write("Czekam na połączenie...");

                    TcpClient klient = serwer.AcceptTcpClient();
                    Console.WriteLine("Połączono!");

                    dane = null;

                    NetworkStream stream = klient.GetStream();

                    int i;

                    while((i=stream.Read(bajt, 0, bajt.Length))!=0)
                    {
                        dane = System.Text.Encoding.ASCII.GetString(bajt, 0, i);
                        Console.WriteLine("Odebrano: {0}", dane);

                        dane = dane.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(dane);

                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Wyślij: {0}", dane);
                    }

                    klient.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                serwer.Stop();
            }

            Console.WriteLine("\nWcisnij przycisk by kontynuować.");
            Console.Read();
        }
    }
}
