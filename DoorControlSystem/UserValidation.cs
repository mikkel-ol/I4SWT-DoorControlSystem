using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class UserValidation : IUserValidation
    {
        private string _correctID = "correctID";

        private bool _validID = false;

        public bool ValidateEntryRequest(string id)
        {
            _validID = false; // simulation multi-threading, so it doesn't stay true forever

            Console.WriteLine("UserValidation::ValidateEntryRequest called");

            if (_correctID == id)
            {
                _validID = true;
            }

            return _validID;
        }
    }
}
