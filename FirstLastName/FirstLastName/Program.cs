using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FirstLastName
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName = "";

            while (string.IsNullOrWhiteSpace(fullName))
            {
                // prompt user for a full name
                Console.WriteLine("Please enter a full name");
                fullName = Console.ReadLine();
            }

            Console.WriteLine();
            Stopwatch timing = new Stopwatch();

            timing.Start();
            Console.WriteLine(FindLastFirstNameByArray(fullName));
            timing.Stop();
            Console.WriteLine("arrays timing was {0}ms", timing.ElapsedMilliseconds);

            timing.Reset();

            timing.Start();
            Console.WriteLine(FindLastFirstName(fullName));
            timing.Stop();
            Console.WriteLine("lists timing was {0}ms", timing.ElapsedMilliseconds);

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// method to find Last and First Name
        /// it also formats the string to have only the first letter capitalized
        /// </summary>
        /// <param name="fullName">string parameter containing full name</param>
        /// <returns>LastName,FirstName</returns>
        static string FindLastFirstName(string fullName)
        {
            List<string> nameList = new List<string>();

            // add all names present on fullName parameter
            nameList.AddRange(fullName.Trim().Split());

            //get first and last name 
            string firstName = nameList.ElementAt(0);
            string lastName = nameList.ElementAt((nameList.Count) - 1);

            return lastName[0].ToString().ToUpper() + lastName.Substring(1).ToLower() + "," + firstName[0].ToString().ToUpper() + firstName.Substring(1).ToLower();
        }

        /// <summary>
        /// method to find Last and First Name using Array
        /// it also formats the string to have only the first letter capitalized
        /// </summary>
        /// <param name="fullName">string parameter containing full name</param>
        /// <returns>LastName,FirstName</returns>
        static string FindLastFirstNameByArray(string fullName)
        {
            string[] nameArray = fullName.Trim().Split();

            //get first and last name 
            string firstName = nameArray[0];
            string lastName = nameArray[nameArray.Length - 1];

            return lastName[0].ToString().ToUpper() + lastName.Substring(1).ToLower() + "," + firstName[0].ToString().ToUpper() + firstName.Substring(1).ToLower();
        }
    }
}
