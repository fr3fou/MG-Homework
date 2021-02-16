using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace AIS_12V_23
{
    using Id = String;

    enum Damage
    {
        Mild = 1,
        Moderate = 2,
        Severe = 3,
    }

    class Repair
    {

        public Id Id { get; set; }
        public Id DeviceId { get; set; }
        public Id CustomerId { get; set; }
        public Id MechanicId { get; set; }

        public string Description { get; set; }
        public Damage Damage { get; set; }
        public DateTime Sent { get; set; }
        public bool Finished { get; set; }
        public bool Received { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Id = \"{Id}\" | CustomerId = \"{CustomerId}\" | MechanicId = \"{MechanicId}\" | DeviceId = \"{DeviceId}\" | Description = \"{Description}\" | Damage = {Damage} | Sent = {Sent} | Repaired = {(Finished ? "Yes" : "No")} | Received = {(Received ? "Yes" : "No")} | Price = {Price:F2} BGN";
        }
    }
}
