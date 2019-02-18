using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class FakeDoor : IDoor
    {
        private bool _HasDoorCloseBeenCalled = false;
        private bool _HasDoorOpenBeenCalled = false;

        public bool GetHasDoorOpenBeenCalled()
        {
            return _HasDoorOpenBeenCalled;
        }

        public bool GetHasDoorCloseBeenCalled()
        {
            return _HasDoorCloseBeenCalled;
        }

        public void Open()
        {
            Console.WriteLine("FakeDoor::Open() called");
            _HasDoorOpenBeenCalled = true;
        }

        public void Close()
        {
            Console.WriteLine("FakeDoor::Close() called");
            _HasDoorCloseBeenCalled = true;
        }
    }
}
