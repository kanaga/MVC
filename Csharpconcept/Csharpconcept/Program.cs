using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharpconcept
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic x = "hello";
            Console.WriteLine(x.Length);
            x = new int[] { 10, 20, 30 };
            Console.WriteLine(x.Length);
            x = 123;
            dynamic y = 10;
            Console.WriteLine(x - y);
            Console.ReadLine();
        }
    }
}
