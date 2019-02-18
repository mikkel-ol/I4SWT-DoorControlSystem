using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class FakeUserValidation : IUserValidation
    {
        private string _correctID = "correctID";

        private bool _validID = false;

        public bool GetWasIDCorrectForTest()
        {
            return _validID;
        }

        public void SetCorrectIDForTest(string correctID)
        {
            _correctID = correctID;
        }

        public bool ValidateEntryRequest(string id)
        {
            Console.WriteLine("FakeUserValidation::ValidateEntryRequest called");

            if (_correctID == id)
            {
                _validID = true;
            }

            return _validID;
        }
    }
}
