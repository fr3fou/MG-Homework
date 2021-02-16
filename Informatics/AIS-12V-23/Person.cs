using System;

namespace AIS_12V_23
{
    using Id = String;

    class Person
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Id = \"{Id}\" | Name = \"{Name}\" | Age = {Age} | PhoneNumber = \"{PhoneNumber}\"";
        }
    }
}
