using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class FakeEntryNotification : IEntryNotification
    {
        private bool _NotifyEntryGrantedCalled = false;
        private bool _NotifyEntryDeniedCalled = false;

        public bool Test_HasNotifyEntryGrantedCalled()
        {
            return _NotifyEntryGrantedCalled;
        }

        public bool Test_HasNotifyEntryDeniedCalled()
        {
            return _NotifyEntryDeniedCalled;
        }


        public void NotifyEntryGranted()
        {
            Console.WriteLine("FakeEntryNotification::NotifyEntryGranted() called");
            _NotifyEntryGrantedCalled = true;
        }

        public void NotifyEntryDenied()
        {
            Console.WriteLine("FakeEntryNotification::NotifyEntryDenied() called");
            _NotifyEntryDeniedCalled = true;
        }
    }
}
