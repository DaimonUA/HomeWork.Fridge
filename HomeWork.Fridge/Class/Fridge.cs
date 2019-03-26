using System;
namespace HomeWork.FridgeEmulator
{
    class Fridge : DeviceT
    {
        public Freeze Freeze { get; }
        public override string Name => "Fridge "+base.Name;
        public Fridge(string name):base(name,1,5)
        {
            Freeze = new Freeze("moroz",this);
        }
        static public void GetMenu()
        {
            FridgeCommand cmd = new FridgeCommand("cd", "создать девайс", "name");
        }

        public override string ToString()
        {
            string res = String.Format("<{0}> {1} door {2} lamp {3}"
                ,Name
                ,(State == Power.On)? "t=" + Temperature + "*C" : "state " + State
                ,Door.State
                ,Lamp.State);
            return res;
        }

    }
}
