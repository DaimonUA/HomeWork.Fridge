
namespace HomeWork.FridgeEmulator
{
    class Fridge : DeviceT
    {
        public Freeze Freeze { get; }
        public string Name => name;

        public Fridge(string name= ""):base(1,5)
        {
            Freeze = new Freeze(this);

            this.name = name;
        }
        static public void GetMenu()
        {
            string res;
            FridgeCommand cmd = new FridgeCommand(id);
            cmd

        }
    }
}
