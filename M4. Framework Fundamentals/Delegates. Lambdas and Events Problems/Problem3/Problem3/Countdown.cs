using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3
{
    public class Countdown
    {
        delegate void WaitingTimeHandler(string message);
        event WaitingTimeHandler Notify;

        public void DisplayMessage(string message) 
        {
            Console.WriteLine(message);
        }
        
    }
}
