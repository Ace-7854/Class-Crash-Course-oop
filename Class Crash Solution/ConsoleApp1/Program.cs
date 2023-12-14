using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
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

            DisplayMenu(list);

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
                catch (Exception)
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
            Console.ReadKey();
        }

        static void DisplayMenu(List<Person> list)
        {
            Console.Clear();

            Console.WriteLine("1: Find User");
            Console.WriteLine("2: Delete user");
            Console.WriteLine("3: Update User");
            Console.WriteLine("4: Add another user");
            Console.WriteLine("5: Display all users");
            Console.WriteLine("6: Exit");

            int Number = IntegerValidation("Please enter the number of your choice: ");

            MenuOptions(Number, list);
        }

        static void MenuOptions(int Input, List<Person> list)
        {
            Console.Clear();

            switch (Input)
            {
                case 1:
                    FindUser(list);
                    break;
                case 2:
                    list = DeleteUser(list);
                    break;
                case 3:
                    list = UpdateUser(list);
                    break;
                case 4:
                    list = AddAnotherUser(list);
                    break;
                case 5:
                    DisplayAllPersons(list);
                    break;
                case 6:
                    Console.WriteLine("Thank you for using AceInc services!");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;

                default: // in the event of a wrong integer is provided
                    Console.WriteLine("Invalid choice. You will shortly be directed back to the menu");
                    Thread.Sleep(3000);
                    DisplayMenu(list);
                    break;
            }
            Console.Clear();
            DisplayMenu(list);
        }

        static void FindUser(List<Person> list)
        {
            Console.WriteLine("Please enter the username of the user");
            string User = Console.ReadLine();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Username.ToLower() == User.ToLower())
                {
                    Console.WriteLine($"Name: {list[i].Name}");
                    Console.WriteLine($"Surname: {list[i].Surname}");
                    Console.WriteLine($"Username: {list[i].Username}");
                    Console.WriteLine($"Address: {list[i].Address}");
                    Console.WriteLine($"Age: {list[i].Age}");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to exit...");
                    Console.ReadKey();

                    DisplayMenu(list);
                }
            }
        }

        static List<Person> DeleteUser(List<Person> list)
        {
            Console.WriteLine("Please enter the username of the user");
            string User = Console.ReadLine();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Username.ToLower() == User.ToLower())
                {

                    Console.WriteLine($"Name: {list[i].Name}");
                    Console.WriteLine($"Surname: {list[i].Surname}");
                    Console.WriteLine($"Username: {list[i].Username}");
                    Console.WriteLine($"Address: {list[i].Address}");
                    Console.WriteLine($"Age: {list[i].Age}");
                    Console.WriteLine();

                    while (true)
                    {
                        Console.WriteLine("Are you sure you want to delete this user? (Y/N)");
                        string choice = Console.ReadLine();

                        if (choice.ToLower() == "y")
                        {
                            list.RemoveAt(i);
                            return list;
                            
                        }
                        else if (choice.ToLower() == "n")
                        {
                            return list;
                        }
                    }
                }
            }

            Console.WriteLine("User was not found");

            Console.WriteLine("Press enter to exit...");
            Console.ReadKey();

            return list;
        }

        static List<Person> UpdateUser(List<Person> list)
        {
            Console.WriteLine("Please enter the username of the user");
            string User = Console.ReadLine();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Username.ToLower() == User.ToLower())
                {
                    Console.WriteLine($"Name: {list[i].Name}");
                    Console.WriteLine($"Surname: {list[i].Surname}");
                    Console.WriteLine($"Username: {list[i].Username}");
                    Console.WriteLine($"Address: {list[i].Address}");
                    Console.WriteLine($"Age: {list[i].Age}");
                    Console.WriteLine();
                    
                    Console.WriteLine("Is this the user? (y/n)");
                    string choice = Console.ReadLine() ;

                    if (choice.ToLower() == "y")
                    {
                        Console.Clear();

                        Person temp = CreateNewPerson();

                        list[i] = temp;

                        return list;
                    }

                }
            }

            Console.WriteLine("User was not found");

            Console.WriteLine("Press enter to exit...");
            Console.ReadKey();

            Console.Clear();
            return list;
        }

        static List<Person> AddAnotherUser(List<Person> list)
        {
            list.Add(CreateNewPerson());

            return list;
        }

    }
}