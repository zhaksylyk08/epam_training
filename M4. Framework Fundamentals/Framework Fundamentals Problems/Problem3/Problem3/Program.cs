using System;
using System.Text;

namespace Problem3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string url = "www.example.com?key=oldValue";
            string keyParameter = "key2=newValue";
            string res = AddOrChangeUrlParameter(url, keyParameter);
            Console.WriteLine(res);
        }

        public static string AddOrChangeUrlParameter(string url, string keyValueParameter) 
        {
            int at = url.IndexOf('?');

            if (at == -1)               // without any key parameter
                return string.Format("{0}?{1}", url, keyValueParameter);
            else                       // with one or more key parameters
            {
                int pos = keyValueParameter.IndexOf('=');
                string key = keyValueParameter.Substring(0, pos);
                string value = keyValueParameter.Substring(pos + 1);

                if (pos > 3)
                    return string.Format("{0}&{1}", url, keyValueParameter);
                else                   // with one key parameter
                {
                    string[] urlsParts = url.Split('?');
                    return string.Format("{0}?key={1}", urlsParts[0], value);
                }
            }
        }
    }
}
