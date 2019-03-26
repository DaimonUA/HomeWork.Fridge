using System;
namespace HomeWork.FridgeEmulator
{
    sealed class Freeze: DeviceT
    {
        private readonly Fridge owner;
        public override string Name => "Freeze "+base.Name;
        internal Freeze(string name,Fridge fridge):base(name,-5,0)
        {
            string messageError = "";
            if (fridge != null && fridge.Freeze == null)
            {
                owner = fridge;
            }
            else
            if (fridge == null)
            {
                messageError = "Нельзя создать морозильную камеру без указания холодильника";
            }
            else //if (fridge.Freeze != null)
            {
                messageError = "Нельзя создать еще одну морозильную камеру холодильника "+fridge.Name;
            } 
            if (messageError != "")
            {
                Exception e = new CreateObjectExeption(messageError);
                throw e;
            }
            temperature = 0;
            name = "Freeze " +name+" / "+owner.Name;
        }
        public override string ToString()
        {
            string res = String.Format("<{0}> owner <{1}> door {2} lamp {3} {4}"
                , Name
                , owner.Name
                , Door.State
                , Lamp.State
                , (State == Power.On) ? "t=" + Temperature + "*C" : "state " + State
                ,State);
            return res;
        }
    }
}
