using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
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

        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                // JObject class comes from the Json.NET/Newtonsoft.Json package we installed
                // has useful methods suck as SelectedToken()
                JObject json = JObject.Parse(response);
                // pull the results token out of the json JObject
                foreach (JToken token in json.SelectTokens("results"))
                {
                    // the JToken "token" contains an array of JObjects, loop over each and pull the "name" tokens out
                    foreach (JObject person in token)
                    {
                        Employee emp = new Employee(
                            person.SelectToken("name.first")!.ToString(),
                            person.SelectToken("name.last")!.ToString(),
                            Int32.Parse(person.SelectToken("id.value")!.ToString().Replace("-", "")),
                            person.SelectToken("picture.large")!.ToString()
                        );
                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }
    }
}