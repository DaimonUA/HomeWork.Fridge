using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.FridgeEmulator
{
    //type:
    //1 - int, 2 - decimal, 3 - int or string
    //0 or ... -string
    internal struct ItemParamers
    {
        public string key;
        public string type;
        public bool mandatory;
        public string keycmd;
        public ItemParamers(string key, string type, bool mandatory,string m="")
        {
            this.key = key;
            this.type = type;
            this.mandatory = mandatory;
            keycmd = m;
        }
    }
}
