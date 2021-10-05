
using Microsoft.Win32;
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
        

        static void Main(string[] args)
        {
            try
            {
                Client client = new Client("", 8000, "GG");
                RegistryKey key = Registry.CurrentUser;

                if (CheakDirectory(key,"ServerInfo") == false)
                {

                    RegistryKey newKey = key.CreateSubKey("ServerInfo");
                    newKey.SetValue("ServerIp", "127.0.0.1");
                    client.ipAddr = newKey.GetValue("ServerIp").ToString();
                    client.CreateIPEndPoint();
                    newKey.Close();
                }
                else
                {
                    RegistryKey newKey = key.OpenSubKey("ServerInfo");
                    
                    client.ipAddr = newKey.GetValue("ServerIp").ToString();
                    client.CreateIPEndPoint();

                    newKey.Close();



                }


                if (CheakDirectory(key, "ConsoleSize") == false)
                {

                    RegistryKey newKey = key.CreateSubKey("ConsoleSize");
                    newKey.SetValue("Width", "800");
                    newKey.SetValue("Hight", "500");
                    newKey.Close();
                }
                else
                {
                    RegistryKey newKey = key.OpenSubKey("ConsoleSize");
         
                    Console.BufferWidth = int.Parse(newKey.GetValue("Width").ToString());
                    Console.BufferHeight = int.Parse(newKey.GetValue("Hight").ToString());
                    newKey.Close();



                }
                
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

        static bool CheakDirectory(RegistryKey key,string foldername)
        {
            foreach (var item in key.GetSubKeyNames())
            {

                if (item.Contains(foldername))
                {
                    return true;
                }
            
            
            
            }
            return false;
        }
    }
}
