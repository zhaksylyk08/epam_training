using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Problem1
{
    public class Customer
    {
        public string Name { get; private set; }
        public decimal Revenue { get; private set; }
        public string ContactPhone { get; private set; }

        public Customer(string name, decimal revenue, string contactPhone) 
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = contactPhone;
        }

        public override string ToString()
        {
            return ToString("A");
        }

        public string ToString(string format) 
        {
            if (string.IsNullOrEmpty(format))
                format = "A";
            string revenueToFormatString = string.Format(CultureInfo.InvariantCulture, "{0:#,#0.00}", Revenue);
            switch (format.ToUpperInvariant()) 
            {
                case "A":
                    return string.Format("Customer record: {0}, {1}, {2}", Name, revenueToFormatString,
                                          ContactPhone);
                case "B":
                    return string.Format("Customer record: {0}", ContactPhone);
                case "C":
                    return string.Format("Customer record: {0}, {1}", Name, revenueToFormatString);
                case "D":
                    return string.Format("Customer record: {0}", Name);
                case "E":
                    return string.Format("Customer record: {0}", revenueToFormatString);
                default:
                    string message = string.Format("{0} is an invalid format string", format);
                    throw new ArgumentException(message);
            }
        }
    }
}
