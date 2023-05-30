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
        async static Task Main(string[] args)
        {
            // List<Employee> employees = PeopleFetcher.GetEmployees();
            List<Employee> employees = await Util.checkRetrievalMethod();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }

    }
}
