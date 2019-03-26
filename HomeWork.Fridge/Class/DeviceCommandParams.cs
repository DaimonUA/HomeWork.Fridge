using System.Collections.Generic;

namespace HomeWork.FridgeEmulator
{
    static class DeviceCommandParams
    {
        readonly public static Dictionary<string,(string,char)> d = new Dictionary<string, (string,char)>();
        static DeviceCommandParams()
        {
            d.Add("name", ("string",'n'));
            d.Add("index", ("int",'i'));
            d.Add("newname", ("string",'a'));
            d.Add("temperature", ("int",'t'));
        }
    }
}
