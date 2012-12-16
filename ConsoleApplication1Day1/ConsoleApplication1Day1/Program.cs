using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = "";
            Console.WriteLine("type the correct sequence of no.");
            Console.ForegroundColor = ConsoleColor.Red;
            num = Console.ReadLine();
            if (num == "4 12 15 24 35")
            {
                Console.Write("you entered the correct seqence of no.");
            }
            else
            {
                Console.WriteLine("Wrong answer");
                Console.Beep();
            }
            Console.ReadLine();


        }
    }
}
