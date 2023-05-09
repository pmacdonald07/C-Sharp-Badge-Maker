// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Much like require or import when using modules in Node.js, in C# the using directive lets us use the
// corresponding namespace (System) without needing to qualify its use when using one of its members

        // Dictionary<string, int> myScoreBoard = new Dictionary<string, int>();
        // myScoreBoard.Add("firstInning", 10);
        // myScoreBoard.Add("secondInning", 20);
        // myScoreBoard.Add("thirdInning", 30);
        // myScoreBoard.Add("fourthInning", 40);
        // myScoreBoard.Add("fifthInning", 50);

        // // same as:
        // Dictionary<string, int> myScoreBoard = new Dictionary<string, int>(){
        // { "firstInning", 10 },
        // { "secondInning", 20},
        // { "thirdInning", 30},
        // { "fourthInning", 40},
        // { "fifthInning", 50}
        // };

        // Console.WriteLine("----------------");
        // Console.WriteLine("  Scoreboard");
        // Console.WriteLine("----------------");
        // Console.WriteLine("Inning |  Score");
        // Console.WriteLine("   1   |    {0}", myScoreBoard["firstInning"]);
        // Console.WriteLine("   2   |    {0}", myScoreBoard["secondInning"]);
        // Console.WriteLine("   3   |    {0}", myScoreBoard["thirdInning"]);
        // Console.WriteLine("   4   |    {0}", myScoreBoard["fourthInning"]);
        // Console.WriteLine("   5   |    {0}", myScoreBoard["fifthInning"]);

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static List<Employee> GetEmployees()
    {
        // I will return a List of strings
        List<Employee> employees = new List<Employee>();

        while (true)
        {
             Console.WriteLine("Enter first name: (leave empty to exit): ");
        // Get a name from the console and assign it to a variable
        // If Console.ReadLine() returned null, then there would be an issue because 
        // the input variable can only hold a string type. To solve for this, we use the null coalescing operator ?? 
        // which is quite similar to a ternary operator. This operator will check for null 
        // and replace the null value with the value after the operator
            string firstName = Console.ReadLine() ?? "";
            // Break if the user hits ENTER without typing a name
            if (firstName == "")
            {
                break;
            }
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine() ?? "";
            Console.Write("Enter ID: ");
            int id = Int32.Parse(Console.ReadLine() ?? "");
            Console.Write("Enter Photo URL: ");
            string photoUrl = Console.ReadLine() ?? "";
            // Create a new Employee instance
            Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
            employees.Add(currentEmployee);
        };

        // this is important!
        return employees;
    }

    async static Task Main(string[] args)
    {
        List<Employee> employees = GetEmployees();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
    }

  }
}
