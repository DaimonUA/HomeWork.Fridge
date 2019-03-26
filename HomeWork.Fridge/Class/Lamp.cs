using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.FridgeEmulator
{
    class Lamp :Device
    {
        private Device owner;
        public override string Name => ("Lamp "+base.Name).Trim();
        internal Lamp(string name, Device owner):base(name)
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

        public override string ToString()
        {
            string res = String.Format("lamp <{0}> owner <{1}> state {2}",Name, owner.Name,State);
            return res;
        }
    }
}
