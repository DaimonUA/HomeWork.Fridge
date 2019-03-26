using System;
using System.Collections.Generic;
using HomeWork.FridgeEmulator;

namespace HomeWork.FridgeEmulator0
{
    class Program
    {
        static void Main(string[] args)
        {
            Fridge f = new Fridge("холодко");
            //Console.WriteLine("холодильник {0} с температурой {1}",f.Name,f.IncreaceTemperature(-6));
            string cd = String.Empty;
            PrintMenu(cd);
            while (true)
            {
                Console.Write("{0}>", cd);

                string cmd = Console.ReadLine().Trim().ToLower();
                switch (cmd)
                {
                    case "q": return;
                    case "":
                        PrintMenu(cd);
                        continue;
                    default: break;
                };
                PrintMenu(cd);
                string resCmd = DeviceCommand.Run(cmd);
                if (resCmd != String.Empty)
                 Console.WriteLine(resCmd);
            }
        }

        static void PrintMenu(string curDevStr)
        {
            Console.Clear();
            Console.WriteLine(DeviceCommand.GetMenuCmd());
            Console.WriteLine("\nTotal device {0}" +
                "\n========================",Device.AllDevice.Count);
            if (DeviceCommand.CurrentDevice != null)
            {
                curDevStr = DeviceCommand.CurrentDevice.Name;
            }
            else
                curDevStr = String.Empty;

        }
    }
}
