using Client_Zoha;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_Zoha_Parsing
{
    class Program
    {
        static int proverca = 0;

        static void Main(string[] args)
        {
            try
            {
         
                Console.Write("Enter Path:");
                string path = Console.ReadLine();
                Client client = new Client("127.0.0.1", 8000, path);
                client.Conect();
                Console.WriteLine(client.TakeMSGFromServ());



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
