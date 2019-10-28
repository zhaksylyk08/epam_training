using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3
{
    public class Countdown
    {
        delegate void AccountHandler(string message);
        event AccountHandler Notify;

        
    }
}
