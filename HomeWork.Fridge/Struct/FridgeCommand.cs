using System;
using System.Collections.Generic;

namespace HomeWork.FridgeEmulator
{
    public struct FridgeCommand
    {
        readonly public string command;
        readonly public string description;

        internal List<ItemParamers> Parameters { get; }

        public FridgeCommand(string command, string description, string mandatoryParametrs="", string noMandatoryParametrs = "")
        {
            this.command = command;
            this.description = description;
            Parameters = new List<ItemParamers>();
            (string,(string,char))[] m0;
            if (ExtractParametersFromString(mandatoryParametrs,out m0))
            {
                foreach ((string,(string,char)) k in m0)
                {
                    Parameters.Add(new ItemParamers(k.Item1, k.Item2.Item1, true));
                }
            }
            (string, (string,char))[] m1;
            if (ExtractParametersFromString(noMandatoryParametrs, out m1))
            {
                foreach ((string, (string,char)) k in m1)
                {
                    Parameters.Add(new ItemParamers(k.Item1, k.Item2.Item1, false,k.Item2.Item2.ToString()));
                }
            }

        }

        private bool ExtractParametersFromString(string str,out (string, (string,char))[] m)
        {
            bool res = true;
            string[] arr = str.Split(',');

            m = new (string, (string,char))[Math.Max(0,arr.Length)];
            if (str == "" || arr.Length == 0)
            {
                return false;
            }

            int ind = 0;
            foreach (string item in arr)
            {
                (string,char) s;
                if (!DeviceCommandParams.d.ContainsKey(item))
                {
                    res = false;
                    string s0 = "Bad parameter name:" + item;
                    throw new Exception(s0);
                }
                else if (DeviceCommandParams.d.TryGetValue(item, out s))
                {
                    m[ind++] = (item, s);
                }
            }
            return res;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FridgeCommand))
            {
                return false;
            }

            var command = (FridgeCommand)obj;
            return EqualityComparer<List<ItemParamers>>.Default.Equals(Parameters, command.Parameters);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Parameters);
        }
    }
}
