using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Did not have time to test");

            List<Person> list = new List<Person>(); //A list of people

            int NumberOfPeople = IntegerValidation("Please enter the number of people you want to add"); //this function will check if the integer is valid and the parameter will be the output

            for (int i = 0; i < NumberOfPeople; i++) //i have taken one away from the number of people as i starts at 0 meaning 2 will be = to 3
            {
                list.Add(CreateNewPerson());
                Console.Clear(); //clears the console window (optional) just keeps ui clean
            }

            DisplayAllPersons(list); //displays all people in the list

            Console.ReadKey(); //allows user time to read after all instructions
        }

        static Person CreateNewPerson()
        {
            Person tempPerson = new Person();

            Console.WriteLine("Please enter your first name");
            tempPerson.Name = Console.ReadLine();

            Console.WriteLine("Please enter your last name");
            tempPerson.Surname = Console.ReadLine();

            Console.WriteLine("Please enter your address");
            tempPerson.Address = Console.ReadLine();

            Console.WriteLine("Please enter your username");
            tempPerson.Username = Console.ReadLine();

            tempPerson.Age = IntegerValidation("Please enter your age"); //checks the integer being used is an integer, with appropriate message

            return tempPerson;
        }

        static int IntegerValidation(string message /*The message is appropraitely displayed for the user*/)
        {
            bool valid = false;
            int Age = 0;

            while (valid != true) //while valid is false do...
            {
                Console.WriteLine(message); //message is displayed
                string Number = Console.ReadLine();
                
                try
                {
                    Age = int.Parse(Number);
                    valid = true; //this is skipped if Number is != an integer
                }
                catch(Exception)
                {
                    Console.WriteLine("Incorrect Format, please give an integer"); //user interrupt
                    valid = false; //Stops the loop
                }

            }
            return Age; //returns valid age
        }

        static void DisplayAllPersons(List<Person> list)
        {
            for (int i = 0; i < list.Count; i++) //foreach person in the list ...
            {
                //all person properties placed here
                Console.WriteLine($"Name: {list[i].Name}");
                Console.WriteLine($"Surname: {list[i].Surname}");
                Console.WriteLine($"Username: {list[i].Username}");
                Console.WriteLine($"Address: {list[i].Address}");
                Console.WriteLine($"Age: {list[i].Age}");
                Console.WriteLine();
            }
        }
    }
}
