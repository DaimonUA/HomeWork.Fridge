using System;

namespace HomeWork.FridgeEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Fridge f = new Fridge();
            try
            {
                Freeze fr = new Freeze(f);
            }
            catch (CreateObjectExeption e)
            {
                Console.WriteLine("Create object error:\n" + e.Message);
            }
            Console.WriteLine(f.IncreaceTemperature(2));
                //Console.WriteLine(fr.Lamp.State);
            //f.Door.Close();
            //if (f.Door.State == DoorState.Open) Console.WriteLine("Open");
            //if (f.Door.State == DoorState.Close) Console.WriteLine("Close");
            //Freeze freeze = new Freeze();
            //Lamp lamp = new Lamp((Device)null);
        }
    }
}
