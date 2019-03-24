using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.FridgeEmulator
{
    class Door:IDoor
    {
        private DoorState state;
        public DoorState State { get => state; private set => state = value; }
        public Door()
        {
            State = DoorState.Close;
        }
        public void Open()
        {
            if (state == DoorState.Close)
            {
                state = DoorState.Open;
            }
        }
        public void Close()
        {
            if (state == DoorState.Open)
            {
                state = DoorState.Close;
            }
        }

    }
}
