using System;

namespace AIS_12V_23
{
    using Id = String;

    class Device
    {
        public Id Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"Id = \"{Id}\" | Make = \"{Make}\" | Model = \"{Model}\"";
        }
    }
}
