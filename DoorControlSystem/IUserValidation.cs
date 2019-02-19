using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public interface IUserValidation
    {
        bool ValidateEntryRequest(string id);
    }
}
