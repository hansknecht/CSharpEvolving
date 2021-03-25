#nullable enable

using System;

namespace NullHandling
{
    class Program
    {
        static void Main(string[] args)
        {
//            int thisCannotBeNull = 4;
//            thisCannotBeNull = null;

            int? thisCouldBeNull = null;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            thisCouldBeNull = 7;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            Address address = new();
            address.Building = null;
            address.Street = "Times";
            address.City = "London";
            address.Region = "UK";
        }
    }
    class Address
    {
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }
}
