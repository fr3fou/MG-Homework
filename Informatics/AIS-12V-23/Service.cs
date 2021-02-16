using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AIS_12V_23
{
    using Id = String;
    class Service
    {
        public Dictionary<Id, Customer> Customers { get; set; }
        public Dictionary<Id, Mechanic> Mechanics { get; set; }
        public Dictionary<Id, Device> Devices { get; set; }
        public Dictionary<Id, Repair> Repairs { get; set; }
        public List<Repair> SortedRepairs
        {
            get => Repairs
                    .OrderByDescending(x => x.Value.Price)
                    .Select(x => x.Value)
                    .ToList();
        }

        public Service()
        {
            Devices = new Dictionary<Id, Device>();
            Customers = new Dictionary<Id, Customer>();
            Mechanics = new Dictionary<Id, Mechanic>();
            Repairs = new Dictionary<Id, Repair>();
        }

        public static Service LoadFromFile(string fileName)
        {
            return JsonSerializer.Deserialize<Service>(File.ReadAllText(fileName));
        }
        public void SaveToFile(string fileName)
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
        }

        public override string ToString()
        {
            StringWriter sw = new StringWriter();

            object[] repairs = SortedRepairs.ToArray();
            object[] finishedRepairs = (from Repair in Repairs where Repair.Value.Finished select Repair.Value).ToArray();
            object[] unfinishedRepairs = (from Repair in Repairs where !Repair.Value.Finished select Repair.Value).ToArray();

            sw.WriteLine("Customers:");
            sw.WriteLine($"     {string.Join("\n     ", Customers.Values)}");
            sw.WriteLine("Mechanics:");
            sw.WriteLine($"     {string.Join("\n     ", Mechanics.Values)}");
            sw.WriteLine("Devices:");
            sw.WriteLine($"     {string.Join("\n     ", Devices.Values)}");
            sw.WriteLine("All Repairs (Sorted):");
            sw.WriteLine($"     {string.Join("\n     ", repairs)}");
            if (repairs.Length > 0)
            {
                sw.WriteLine("Finished Repairs:");
                sw.WriteLine($"     {string.Join("\n     ", finishedRepairs)}");
                sw.WriteLine("Unfinished Repairs:");
                sw.WriteLine($"     {string.Join("\n     ", unfinishedRepairs)}");
                sw.WriteLine("Average Price for Repair:");
                sw.WriteLine($"     {Repairs.Average(v => v.Value.Price):F2}");
                sw.WriteLine("Most Expensive Repair:");
                sw.WriteLine($"     {SortedRepairs.Where(v => v.Finished).First()}");
                sw.WriteLine("Oldest Repair:");
                sw.WriteLine($"     {Repairs.OrderBy(v => v.Value.Sent).Select(v => v.Value).First()}");
            }

            return sw.ToString();
        }
        public Customer NewCustomer(string name, int age, string phoneNumber)
        {
            Id id = NewId();
            Customer customer = new Customer { Id = id, Name = name, Age = age, PhoneNumber = phoneNumber };
            Customers[id] = customer;
            return customer;
        }
        public Mechanic NewMechanic(string name, int age, string phoneNumber)
        {
            Id id = NewId();
            Mechanic mechanic = new Mechanic { Id = id, Name = name, Age = age, PhoneNumber = phoneNumber };
            Mechanics[id] = mechanic;
            return mechanic;
        }
        public Device NewDevice(string make, string model)
        {
            Id id = NewId();
            Device device = new Device { Id = id, Make = make, Model = model };
            Devices[id] = device;
            return device;
        }
        public Repair NewRepair(Id deviceId, Id customerId, Id mechanicId, string description, double price, Damage damage)
        {
            try
            {
                _ = Customers[customerId];
                _ = Mechanics[mechanicId];
                _ = Devices[deviceId];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("Customer, Mechanic or Device does not exist.");
            }

            Id id = NewId();
            Repair task = new Repair
            {
                Id = id,
                DeviceId = deviceId,
                CustomerId = customerId,
                MechanicId = mechanicId,
                Description = description,
                Sent = DateTime.Now,
                Finished = false,
                Received = false,
                Price = price,
                Damage = damage,
            };

            Repairs[id] = task;

            return task;
        }

        public Customer GetCustomer(Id id)
        {
            return Customers[id];
        }
        public Repair[] GetCustomerRepairs(Id id)
        {
            return Repairs.Where(kv => kv.Value.CustomerId == id).Select(v => v.Value).ToArray();
        }
        public Mechanic GetMechanic(Id id)
        {
            return Mechanics[id];
        }
        public Repair[] GetMechanicRepairs(Id id)
        {
            return Repairs.Where(kv => kv.Value.MechanicId == id).Select(v => v.Value).ToArray();
        }
        public Device GetDevice(Id id)
        {
            return Devices[id];
        }
        public Repair GetRepair(Id id)
        {
            return Repairs[id];
        }

        public Customer UpdateCustomer(Id id, string name, int age, string phoneNumber)
        {
            Customers[id].Name = name;
            Customers[id].Age = age;
            Customers[id].PhoneNumber = phoneNumber;
            return Customers[id];
        }
        public Mechanic UpdateMechanic(Id id, string name, int age, string phoneNumber)
        {
            Mechanics[id].Name = name;
            Mechanics[id].Age = age;
            Mechanics[id].PhoneNumber = phoneNumber;
            return Mechanics[id];
        }
        public Device UpdateDevice(Id id, string make, string model)
        {
            Devices[id].Make = make;
            Devices[id].Model = model;
            return Devices[id];
        }
        public Repair UpdateRepair(Id id, Id deviceId, Id customerId, Id mechanicId, string description, bool finished, bool received, double price, Damage damage)
        {
            Repairs[id].DeviceId = deviceId;
            Repairs[id].CustomerId = customerId;
            Repairs[id].MechanicId = mechanicId;
            Repairs[id].Finished = finished;
            Repairs[id].Received = received;
            Repairs[id].Price = price;
            Repairs[id].Damage = damage;
            Repairs[id].Description = description;

            return Repairs[id];
        }

        public void DeleteCustomer(Id id)
        {
            Customers.Remove(id);
            foreach (var item in Repairs.Where(kvp => kvp.Value.CustomerId == id).ToList())
            {
                Repairs.Remove(item.Key);
            }
        }
        public void DeleteMechanic(Id id)
        {
            Mechanics.Remove(id);
            foreach (var item in Repairs.Where(kvp => kvp.Value.MechanicId == id).ToList())
            {
                Repairs.Remove(item.Key);
            }
        }
        public void DeleteDevice(Id id)
        {
            Devices.Remove(id);
            foreach (var item in Repairs.Where(kvp => kvp.Value.DeviceId == id).ToList())
            {
                Repairs.Remove(item.Key);
            }
        }
        public void DeleteRepair(Id id)
        {
            Repairs.Remove(id);
        }

        private Id NewId()
        {
            return Guid.NewGuid().ToString().Substring(0, 4);
        }
    }
}
