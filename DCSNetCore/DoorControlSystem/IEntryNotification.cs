using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public interface IEntryNotification
    {
        void NotifyEntryGranted();
        void NotifyEntryDenied();
    }
}
