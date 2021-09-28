using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Zoha_Parsing
{
    class Program
    {
        static int port = 8000;
        static int bytes = 0;

        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static string str = String.Empty;
      
        static Dictionary<string, int> Count_Words = new Dictionary<string, int>();
        static Socket socketClient;
        static List<Client> clients = new List<Client>();
        static void Main(string[] args)
        {

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            
            Console.WriteLine("Start server...");
            try
            {
                                
                    socket.Bind(iPEndPoint);
                    socket.Listen(10);
                Task.Factory.StartNew(() => Conection());
                while (true)
                {
                    if (clients.Count() > 0)
                    {
                        SendMsgToALL();

                    }

                }
               
              








            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static bool WriteFile(string path)
        {
            try
            {
                byte[] data = new byte[int.Parse(GetFileSize(socketClient))];
                StringBuilder stringBuilder = new StringBuilder();
                do
                {
                    bytes = socketClient.Receive(data);
                    stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (socketClient.Available > 0);

                File.WriteAllBytes(Path.GetFileName(path), data);

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        static string GetFileName(Socket clientSoc)
        {

            StringBuilder stringBuilder = new StringBuilder();
            byte[] data = new byte[256];

            do
            {
                bytes = clientSoc.Receive(data);
                stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            } while (socketClient.Available > 0);

            return stringBuilder.ToString();
        }


        static string GetFileSize(Socket clientSoc)
        {

            StringBuilder stringBuilder = new StringBuilder();
            byte[] data = new byte[256];

            do
            {
                bytes = clientSoc.Receive(data);
                stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            } while (socketClient.Available > 0);

            return stringBuilder.ToString();
        }

        static void SendMsgToClien(Socket clientSoc,string msg)
        {

            clientSoc.Send(Encoding.Unicode.GetBytes(msg));
        
        
        }

        static void Conection()
        {
            while (true)
            {
              
                clients.Add(new Client("127.0.0.1",port,"GG",socket.Accept()));
              
            }
        }

        static void SendMsgToALL()
        {
            for (int i = 0; i < clients.Count(); i++)
            {

                SendMsgToClien(clients[i].socket,"Welcome To Server");

            }


        }


    }


}
