namespace HomeWork.FridgeEmulator
{
    class Fridge : Device
    {
        public Door Door { get;}
        //public Door Door { get; }
        public Fridge()
        {
            Door = new Door();
        }
    }
}
