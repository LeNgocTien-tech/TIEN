using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


     

// Define a class to represent a customer
public class Customer
        {
            public string Name { get; set; }
            public int LastMonthReading { get; set; }
            public int ThisMonthReading { get; set; }
            public int NumberOfPeople { get; set; }
            public string CustomerType { get; set; } // Household, Administrative, Production, Business

            public Customer(string name, int lastMonthReading, int thisMonthReading, int numberOfPeople, string customerType)
            {
                Name = name;
                LastMonthReading = lastMonthReading;
                ThisMonthReading = thisMonthReading;
                NumberOfPeople = numberOfPeople;
                CustomerType = customerType;
            }

            // Calculate the consumption in cubic meters
            public int CalculateConsumption()
            {
                return ThisMonthReading - LastMonthReading;
            }

    // Calculate the total water bill
    public double CalculateWaterBill()
    {
        int consumption = CalculateConsumption();
        double unitPrice = 0;
        double environmentFee = 0.1; // 10% environment protection fee

        switch (CustomerType.ToLower())
        {
            case "household":
                if (NumberOfPeople > 0)
                {
                    int consumptionPerPerson = consumption / NumberOfPeople;
                    if (consumptionPerPerson <= 10)
                        unitPrice = 5.973;
                    else if (consumptionPerPerson <= 20)
                        unitPrice = 7.052;
                    else if (consumptionPerPerson <= 30)
                        unitPrice = 8.699;
                    else
                        unitPrice = 15.929;
                }
                break;
            case "administrative":
            case "public services":
                unitPrice = 9.955;
                break;
            case "production":
                unitPrice = 11.615;
                break;
            case "business":
            case "business services":
                unitPrice = 22.068;
                break;
            default:
                throw new ArgumentException("Invalid customer type");
        }

        // Calculate total bill including environment protection fee (excluding VAT)
        double totalBill = consumption * unitPrice * (1 + environmentFee);

        return totalBill;
    }
        class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter last month's water meter readings:");
            int lastMonthReading = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter this month's water meter readings:");
            int thisMonthReading = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of people (for household type, otherwise enter 0):");
            int numberOfPeople = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter customer type (household, administrative, production, business):");
            string customerType = Console.ReadLine().ToLower(); // Convert to lower case for case insensitivity

            // Create a customer object
            Customer customer = new Customer(name, lastMonthReading, thisMonthReading, numberOfPeople, customerType);

            // Calculate the water bill
            double totalBill = customer.CalculateWaterBill();

            // Output the bill details
            Console.WriteLine();
            Console.WriteLine("Customer Name: " + customer.Name);
            Console.WriteLine("Last Month's Reading: " + customer.LastMonthReading);
            Console.WriteLine("This Month's Reading: " + customer.ThisMonthReading);
            Console.WriteLine("Consumption: " + customer.CalculateConsumption() + " cubic meters");
            Console.WriteLine("Total Water Bill: " + totalBill.ToString("C2")); // Display as currency

            Console.ReadLine(); // Keep console window open
        }
    }

}
        

    


