using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoorControlSystem
{
    public class Alarm : IAlarm
    {
        public void RaiseAlarm()
        {
            Console.WriteLine("Alarm::RaiseAlarm() called");
        }
    }
}
