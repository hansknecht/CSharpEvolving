using System;
using static System.Console;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter the number to increment to: ");
            string input = ReadLine();
            int max = 0;
            try
            {
                int.TryParse(input, out max);
            }
            catch (FormatException)
            {
                WriteLine($"You entered {input}, but we need an integer.");
            }
            for (int i = 1; i <= max; i++)
            {
                string buzzy = string.Empty;
                if ((i % 3) == 0)
                {
                    buzzy += "fizz";
                }
                if ((i % 5) == 0)
                {
                    buzzy += "buzz";
                }
                buzzy = (buzzy == string.Empty ? i.ToString() : buzzy);
                WriteLine($"{buzzy}");
            }


        }
    }
}
