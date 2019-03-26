using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeWork.FridgeEmulator
{
    abstract public class Device : IDevice,IDisposable
    {
        private string name;
        protected bool state;
        public Power State
        {
            get => state ? Power.On : Power.Off;
            private set => state = (value == Power.On) ? true : false;
        }
        public virtual string Name { get => name.ToUpper(); private set => name = value.ToUpper(); }

        public static List<Device> AllDevice => allDevice;

        private static readonly List<Device> allDevice = new List<Device>();

        public void Off() => State = Power.Off;
        public void On() => State = Power.On;

        public Device(string name)
        {
            this.name = name;
            allDevice.Add(this);

        }
        ~Device()
        {
        }
        public bool Rename(string newname)
        {
            bool res = false;
            if (newname != name)
            {
                name = newname;
                res = true;
            }
            return res;
        }

        public void Dispose()
        {
            int ind = allDevice.IndexOf(this);
            if (ind != -1) allDevice.RemoveAt(ind);
        }
    }
}
