using System;
using System.Collections.Generic;

namespace BrainfuckInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Interpreter ip = new Interpreter();
            string code = "++++++[>++++++++++<-]>+++++.+.+.+.";

            ip.Parse(code);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
