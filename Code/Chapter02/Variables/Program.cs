using System;
using System.IO;
using System.Xml;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88;
            object name = "Amir";
            Console.WriteLine($"{name} is {height} metres tall.");

            //int length1 = name.Length;
            int length2 = ((string)name).Length;
            Console.WriteLine($"{name} has {length2} characters.");

            dynamic anotherName = "Ahmed";
            int length = anotherName.Length;
            Console.WriteLine($"{anotherName} has {length} characters.");

//            var xml1 = new XmlDocument(); // good use of var
//            XmlDocument xml2 = new XmlDocument(); // otherwise you have a repatative presentation
//
//            var file1 = File.CreateText(@"C:\something.txt"); // poor use of var
//            StreamWriter file2 = File.CreateText(@"C:\something.txt"); // better case to use full type name

            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default(bool) = {default(bool)}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(stirng) = {default(string)}");


        }
    }
}
