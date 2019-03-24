namespace HomeWork.FridgeEmulator
{
    class Fridge : Device
    {

       // Power State { get; set => throw new System.NotImplementedException(); }
        public Power State
        {
            get; set => state = (value == Power.On) ? true : false;
        }
        override void Mcrosoft()
        {

        }
    }
}
