using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.FridgeEmulator
{
    struct FridgeCommand
    {
        string command;
        string description;
        List<ItemParamers> parametrs;

        public FridgeCommand(string command, string description, string mandatoryParametrs="", string noMandatoryParametrs = "")
        {
            this.command = command;
            this.description = description;
            parametrs = new List<ItemParamers>();
            //parametrs.Add()
        }
    }
}
