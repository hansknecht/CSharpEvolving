using System;
using static System.Console;

namespace Arguments
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"There are {args.Length} arguments");
            foreach (string arg in args)
            {
                WriteLine(arg);
            }

            if (args.Length < 3)
            {
                WriteLine("You must specifiy two colors and cursor size, e.g.");
                WriteLine("dotnet run red yellow 50");
                return;
            }


            ForegroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[0],
                ignoreCase: true);
        

            BackgroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[1],
                ignoreCase: true);

            WriteLine(OperatingSystem.IsWindows());
            
            try
            {
                CursorSize = int.Parse(args[2]);
            }
            catch (Exception e)
            {
                WriteLine("The current platform does not suport changin the size of the cursor");
                WriteLine($"{e}");
            }
        

        }
    }
}
