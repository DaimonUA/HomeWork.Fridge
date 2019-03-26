using temper = HomeWork.FridgeEmulator.Temperature;
namespace HomeWork.FridgeEmulator
{
    abstract class DeviceT:Device,ITemperature
    {
        public readonly sbyte temperatureMin;
        public readonly sbyte temperatureMax;
        protected sbyte temperature;
        public sbyte Temperature
        {
            get => temperature;
            internal set => temperature = temper.Change(this, value, true);
        }
        public Door Door { get; }
        public Lamp Lamp { get; }
        public sbyte IncreaceTemperature(sbyte step = 1)
        {
            return temper.Change(this, step);
        }

        public sbyte ReduceTemperature(sbyte step = 1)
        {
            return temper.Change(this, step);
        }
        public DeviceT(string name, sbyte minT, sbyte maxT):base(name)
        {
            temperatureMin = minT;
            temperatureMax = maxT;
            Door = new Door();
            Lamp = new Lamp("",this);
        }

    }
}
