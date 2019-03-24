using System;

namespace HomeWork.FridgeEmulator
{
    internal static class Temperature
    {
        internal static sbyte Change(DeviceT obj, sbyte step, bool isRecursion=false)
        {
            sbyte temp = (sbyte)(obj.Temperature + step);
            temp = (sbyte)Math.Min(obj.temperatureMax, Math.Max(temp, obj.temperatureMin));

            if (!isRecursion)
            {
              obj.Temperature = temp;
            }
            return temp;
        }
    }
}
