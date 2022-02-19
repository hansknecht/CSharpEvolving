using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class thingOfDefaults
    {
        public int Population;
        public DateTime When;
        public string Name;
        public List<Person> People;

        public thingOfDefaults()
        {
            Population = default; // used to be before #7.1 default(int);
            When = default; // default(DateTime);
            Name = default; // default(string);
            People = default; //default(List<Person>);
        }
    }
}