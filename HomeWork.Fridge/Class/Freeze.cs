using System;
namespace HomeWork.FridgeEmulator
{
    sealed class Freeze: DeviceT
    {
        private readonly Fridge owner;

        internal Freeze(Fridge fridge):base(-5,0)
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
            name = "Freeze " + owner.Name;
        }
    }
}
