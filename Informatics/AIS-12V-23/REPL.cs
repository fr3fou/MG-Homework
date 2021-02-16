using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AIS_12V_23
{
    using Id = String;
    class REPL
    {
        private static Service srv = new Service();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase)
        {
            { "Help", Help },
            { "List", List },
            { "New-Device", NewDevice },
            { "New-Customer", NewCustomer },
            { "New-Mechanic", NewMechanic },
            { "New-Repair", NewRepair },
            { "Get-Customer", GetCustomer },
            { "Get-Customer-Repairs", GetCustomerRepairs },
            { "Get-Device", GetDevice },
            { "Get-Mechanic", GetMechanic },
            { "Get-Mechanic-Repairs", GetMechanicRepairs },
            { "Get-Repair", GetRepair },
            { "Update-Customer", UpdateCustomer },
            { "Update-Device", UpdateDevice },
            { "Update-Mechanic", UpdateMechanic },
            { "Update-Repair", UpdateRepair },
            { "Delete-Customer", DeleteCustomer },
            { "Delete-Device", DeleteDevice },
            { "Delete-Mechanic", DeleteMechanic },
            { "Delete-Repair", DeleteRepair },
            { "Set-Repair-Status", SetRepairStatus },
            { "Load", Load },
            { "Save", Save },
            { "Clear-Screen", ClearScreen },
            { "Clear", ClearScreen },
            { "Reset", Reset },
        };

        public static void Start()
        {
            Console.WriteLine("Hello! Welcome to AIS-PC-Service");
            Console.WriteLine("Enter a command! Type `Quit` to stop the program. Available commands:");
            Help();
            string command;
            while (true)
            {
                try
                {
                    command = PromptString("Command");
                    if (command == "quit") break;
                    if (!_commands.ContainsKey(command))
                    {
                        Console.WriteLine("Invalid Command! Run `help` to list available commands!"); 
                        continue;
                    }
                    _commands[command]();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error! {0}", e);
                }
            }
            Console.WriteLine("Quitting...");
        }

        private static void Reset()
        {
            srv = new Service();
        }
        private static void Help()
        {
            Console.WriteLine("   " + string.Join("\n   ", _commands.Keys));
        }
        private static void Load()
        {
            srv = Service.LoadFromFile(PromptString("Path To File"));
            List();
        }
        private static void Save()
        {
            srv.SaveToFile(PromptString("Path To File"));
        }
        private static void List()
        {
            Console.Write(srv.ToString());
        }
        private static void ClearScreen()
        {
            Console.Clear();
        }

        private static void NewDevice()
        {
            srv.NewDevice(
                PromptString("Make"),
                PromptString("Model")
            );
        }
        private static void NewCustomer()
        {
            srv.NewCustomer(
                PromptString("Name"),
                PromptInt("Age"),
                PromptString("Phone Number")
            );
        }
        private static void NewMechanic()
        {
            srv.NewMechanic(
                PromptString("Name"),
                PromptInt("Age"),
                PromptString("Phone Number")
            );
        }
        private static void NewRepair()
        {
            srv.NewRepair(
                PromptString("Device Id"),
                PromptString("Customer Id"),
                PromptString("Mechanic Id"),
                PromptString("Description"),
                PromptDouble("Price"),
                PromptDamage()
            );
        }

        private static void GetCustomer()
        {
            Console.WriteLine(srv.GetCustomer(PromptString("Id")));
        }
        private static void GetCustomerRepairs()
        {
            Id id = PromptString("Id");
            object[] repairs = srv.GetCustomerRepairs(id);
            Console.WriteLine($"Customer {id} repairs:");
            Console.WriteLine($"     {string.Join("     \n", repairs)}");
        }
        private static void GetMechanic()
        {
            Console.WriteLine(srv.GetMechanic(PromptString("Id")));
        }
        private static void GetMechanicRepairs()
        {
            Id id = PromptString("Id");
            object[] repairs = srv.GetMechanicRepairs(id);
            Console.WriteLine($"Mechanic {id} repairs:");
            Console.WriteLine($"     {string.Join("     \n", repairs)}");
        }
        private static void GetDevice()
        {
            Console.WriteLine(srv.GetDevice(PromptString("Id")));
        }
        private static void GetRepair()
        {
            Console.WriteLine(srv.GetRepair(PromptString("Id")));
        }

        private static void UpdateDevice()
        {
            srv.UpdateDevice(
                PromptString("Id"),
                PromptString("Make"),
                PromptString("Model")
            );
        }
        private static void UpdateCustomer()
        {
            srv.UpdateCustomer(
                PromptString("Id"),
                PromptString("Name"),
                PromptInt("Age"),
                PromptString("Phone Number")
            );
        }
        private static void UpdateMechanic()
        {
            srv.UpdateMechanic(
                PromptString("Id"),
                PromptString("Name"),
                PromptInt("Age"),
                PromptString("Phone Number")
            );
        }
        private static void UpdateRepair()
        {
            srv.UpdateRepair(
                PromptString("Id"),
                PromptString("Device Id"),
                PromptString("Customer Id"),
                PromptString("Mechanic Id"),
                PromptString("Description"),
                PromptBool("Finished"),
                PromptBool("Received"),
                PromptDouble("Price"),
                PromptDamage()
            );
        }

        private static void DeleteCustomer()
        {
            srv.DeleteCustomer(PromptString("Id"));
        }
        private static void DeleteMechanic()
        {
            srv.DeleteMechanic(PromptString("Id"));
        }
        private static void DeleteDevice()
        {
            srv.DeleteDevice(PromptString("Id"));
        }
        private static void DeleteRepair()
        {
            srv.DeleteCustomer(PromptString("Id"));
        }

        private static void SetRepairStatus()
        {
            Id id = PromptString("Id");
            bool finished = PromptBool("Finished");
            bool received = PromptBool("Received");
            Repair rep = srv.GetRepair(id);
            srv.UpdateRepair(id, rep.DeviceId, rep.CustomerId, rep.MechanicId, rep.Description, finished, received, rep.Price, rep.Damage);
        }

        private static string PromptString(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine().Trim();
        }
        private static int PromptInt(string prompt)
        {
            Console.Write($"{prompt}: ");
            return int.Parse(Console.ReadLine().Trim());
        }
        private static double PromptDouble(string prompt)
        {
            Console.Write($"{prompt}: ");
            return double.Parse(Console.ReadLine().Trim());
        }
        private static bool PromptBool(string prompt)
        {
            Console.Write($"{prompt} [Y/n]: ");
            var input = Console.ReadLine().Trim().ToLower();
            return input == "y" || input == "";
        }
        private static Damage PromptDamage()
        {
            Console.Write($"Damage [Mild (1), Moderate (2), Severe (3)]: ");
            return (Damage)int.Parse(Console.ReadLine().Trim());
        }
    }
}
