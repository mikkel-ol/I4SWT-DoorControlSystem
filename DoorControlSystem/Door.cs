using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class Door : IDoor
    {
        public void Open()
        {
            Console.WriteLine("Door::Open() called");
        }

        public void Close()
        {
            Console.WriteLine("Door::Close() called");
        }
    }
}
