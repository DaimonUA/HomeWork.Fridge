using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.FridgeEmulator
{
    static class DeviceCommand
    {
        static private int currentDeviceIndex = -1;
        static public Device CurrentDevice
        {
            get
            {
                Device d = null;
                if (currentDeviceIndex >= 0 && Device.AllDevice.Count >= currentDeviceIndex)
                {
                    d = Device.AllDevice[currentDeviceIndex];
                }
                else currentDeviceIndex = -1;

                return d;
            }
            private set { }
        }
        public readonly static Dictionary<string,FridgeCommand> commands = new Dictionary<string,FridgeCommand>();
        static DeviceCommand()
        {
            //commands.Clear();
            commands.Add("cd",new FridgeCommand("cd", "создать девайс", "name"));
            commands.Add("sc",new FridgeCommand("sc", "установить текущий девайс", "name"));
            commands.Add("rn",new FridgeCommand("rn", "переименовать девайс", "name","newname"));
            commands.Add("l",new FridgeCommand("l", "список девайсов"));
            commands.Add("del",new FridgeCommand("del", "удалить девайс","","index"));
            commands.Add("q", new FridgeCommand("q", "exit"));

            currentDeviceIndex = -1;

        }

        public static string GetMenuCmd()
        {
            string res="====Command menu====={\n";
            foreach (KeyValuePair<string, FridgeCommand> item in DeviceCommand.commands)
            {
                string str = " "; string strPar = String.Empty;
                string separ = "";
                foreach (ItemParamers ip in item.Value.Parameters)
                {
                    if (!ip.mandatory)
                    {
                        str += "[" + separ + ip.keycmd + " " + ip.key + "]";
                        strPar += "-" + ip.key + " (" + ip.type + ") необязательный\n";
                    }
                    else
                    {
                        str += separ + ip.key;
                        strPar += "-" + ip.key + " (" + ip.type + ") обязательный\n";
                    }
                    separ = ",";
                }
                strPar = "\n"+ strPar;
                res += String.Format("{0}{1}\t\t{2}{3}",item.Value.command,str, item.Value.description, strPar);
            }
            res += "====Command menu=====}";
            return res;
        }

        public static string Run(string cmd)
        {
            cmd = cmd.Trim().ToLower();
            if (cmd == string.Empty) return "";

            string[] arr = cmd.Split(' ');
            string command = arr[0];

            FridgeCommand fc;
            if (!commands.TryGetValue(arr[0],out fc)) return "";

            if (!SetArguments(fc, arr)) return "";

            //if ()

            string res = "";
            switch (cmd)
            {
                case "l":
                    res = ListDevise();
                    break;
                case "sc":
                    break;
                default: break;
            }
            return res;
        }

        static bool SetArguments(FridgeCommand fc, string[] arr)
        {
            bool res = true;

            if (
                (fc.Parameters.Count > 0 && arr.Length == 1)
                || (fc.Parameters.Count == 0 && arr.Length > 1)
                )
            {
                return false;
            }

            if (fc.Parameters.Count == 0 && arr.Length == 1)
                return true;
            int ind = 1;
            foreach (ItemParamers p in fc.Parameters)
            {
                if (!res) break;
                if (!p.mandatory)
                {
                    ind++;
                }
                if (ind >= arr.Length)
                {
                    if (p.mandatory)
                    res = false;
                    break;
                }
                string curValue = arr[ind].Trim();
                if (curValue == String.Empty) {
                    ind++;
                    continue;
                }

                if (!p.mandatory)
                {
                    if (arr[ind - 1] != p.keycmd)
                    {
                        res = false;
                        break;
                    }
                }
                object tmp;
                int tmpint;
                switch (p.type)
                {
                    case "int":
                        if (!int.TryParse(curValue, out tmpint))
                        {
                            res = false;
                        }
                        else
                            tmp = tmpint;
                        break;
                    default:
                        res = false;
                        break;
                }
                ind++;
            }
            return res;
        }

        static private string ListDevise()
        {
            string res = "";
            string nstr = "";
            int ind = 0;
            foreach (Device d in Device.AllDevice)
            {
                res += String.Format(nstr+"[{0}] {1}", ind++, d);
                nstr = "\n";
            }
            return res;
        }
    }
}
