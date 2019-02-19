using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class EntryNotification :IEntryNotification
    {
        public void NotifyEntryGranted()
        {
            Console.WriteLine("EntryNotification::NotifyEntryGranted() called");
        }

        public void NotifyEntryDenied()
        {
            Console.WriteLine("EntryNotification::NotifyEntryDenied() called");
        }
    }
}
