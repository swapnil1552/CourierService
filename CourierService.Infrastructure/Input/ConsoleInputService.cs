using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Infrastructure.Input
{
    public class ConsoleInputService
    {
        public static void WelcomeNote()
        {
            Console.WriteLine("Welcome to Kiki Courier Service");
        }
        public int ReadBaseDeliveryCost()
        {
            Console.WriteLine("Enter the Base Delivery Cost");
            return ReadPostiveInt();
        }

        public int ReadPackageCount()
        {
            Console.WriteLine("Enter the Number of Packages");
            return ReadPostiveInt();
        }

        public List<Package> ReadPackages(int count)
        {
            var packages = new List<Package>();

            for (int i = 0; i < count; i++)
            {
                var package = new Package();
                Console.WriteLine("Enter the Package Id");
                package.Id = Console.ReadLine();
                Console.WriteLine("Enter the Package Weight");
                package.Weight = ReadPostiveDouble();
                Console.WriteLine("Enter the Distance in Km");
                package.Distance = ReadPostiveDouble();
                Console.WriteLine("Enter the Offer Code");
                package.OfferCode = Console.ReadLine();
                packages.Add(package);
            }

            return packages;
        }

        public List<Vehicle> ReadVehicles()
        {
            var listOfVehicle = new List<Vehicle>();
            Console.WriteLine("Enter the number of vehicles");
            int vehicleCount = ReadPostiveInt();

            Console.WriteLine("Enter the Maximum Speed");
            double speed = ReadPostiveDouble();
            Console.WriteLine("Enter the Maximum Weight Vehicle can carry");
            double weight = ReadPostiveDouble();

            for (int i = 0; i < vehicleCount; i++)
            {
                listOfVehicle.Add(new Vehicle { Id = i, MaxWeight = weight, Speed = speed });
            }

            return listOfVehicle;
        }

        private double ReadPostiveDouble()
        {
            while(true)
            {
                if (double.TryParse(Console.ReadLine(), out double value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Invalid input, Enter a positive number");
            }
            
        }

        private int ReadPostiveInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Invalid Input, Enter a positive number");
            }

        }
    }
}
