﻿
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
         
             
                Client client = new Client("127.0.0.1", 8000, "GG");
                client.Conect();
                while (true)
                {
                    Console.WriteLine(client.TakeMSGFromServ());

                }
                



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
