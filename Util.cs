using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;

namespace CatWorx.BadgeMaker
{
    class Util
    {
        // Method declared as "static"
        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
        {
            // We want the first argument (argument {0}), the id, to be left-aligned and padded to at least 10 characters, so we enter {0,-10}.
            // Then we want to print a tab character (\t). We want the next argument ({1}), the name, to be left-aligned and padded to 20 characters—hence {1,-20}.
            // Next, we want to print another tab character (\t). And finally, we want to print the last argument ({2}), the photo URL, with no formatting: {2}.
            string template = "{0, -10}\t{1, -20}\t{2}";
            Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
        }
        }

        public static void MakeCSV(List<Employee> employees) {
            // Check to see if folder exists
            if (!Directory.Exists("data"))
            {
                // If not, create it
                Directory.CreateDirectory("data");
            }
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    // We want the first argument (argument {0}), the id, to be left-aligned and padded to at least 10 characters, so we enter {0,-10}.
                    // Then we want to print a tab character (\t). We want the next argument ({1}), the name, to be left-aligned and padded to 20 characters—hence {1,-20}.
                    // Next, we want to print another tab character (\t). And finally, we want to print the last argument ({2}), the photo URL, with no formatting: {2}.
                    string template = "{0, -10}\t{1, -20}\t{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }

        public static void MakeBadges(List<Employee> employees) {

        }
    }
};