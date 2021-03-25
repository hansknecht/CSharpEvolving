using System;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 500;
            checked
            {
                for (byte i = 0; i < max; i++)
                {
                    WriteLine(i);
                }
            }
        }
    }
}
