using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.FridgeEmulator
{
    class Lamp :Device
    {
        private Device owner;
        internal Lamp(Device owner)
        {
            if (owner != null)
            {
                this.owner = owner;
            }
            else
            {
                Exception e = new CreateObjectExeption("Нельзя создавать лампу без владельца");
                throw e;
            }
                
        }
    }
}
