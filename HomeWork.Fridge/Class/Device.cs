namespace HomeWork.FridgeEmulator
{
    abstract public class Device:IDevice
    {
        protected string name;
        protected bool state;
        public Power State
        {
            get => state ? Power.On : Power.Off;
            private set => state = (value == Power.On) ? true : false;
        }

        public void Off() => State = Power.Off;
        public void On() => State = Power.On;
    }
}
