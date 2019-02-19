using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class DoorControl
    {
        private IDoor _door = null;
        private IEntryNotification _entryNotification = null;
        private IUserValidation _userValidation = null;

        public DoorControl(IDoor door, IEntryNotification entryNotif, IUserValidation userValidation)
        {
            _door = door;
            _entryNotification = entryNotif;
            _userValidation = userValidation;
        }


        public void RequestEntry(string id)
        {
            if(_userValidation.ValidateEntryRequest(id))
            {
                _door.Open();
                _entryNotification.NotifyEntryGranted();
            }
            else
            {
                // not implemented yet, part exercise 4
            }
        }

        public void DoorOpen()
        {
            // After the door has opened, it must close
            _door.Close();
        }

        public void DoorClosed()
        {
            Console.WriteLine("Door has been closed");
        }

        public void DoorOpened()
        {
            // not implemented yet, part exercise 4
        }
    }
}
