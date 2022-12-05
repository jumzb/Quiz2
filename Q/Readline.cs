using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public static class MyConsole
    {
        public static string ReadLine(string line)
        {
            Console.WriteLine(line);
            return Console.ReadLine();
        }
    }
}
