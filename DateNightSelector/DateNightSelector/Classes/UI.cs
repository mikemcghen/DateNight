using DateNightSelector.DAO;
using DateNightSelector.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DateNightSelector.Classes
{
    public class UI
    {
        private readonly IDatesDAO datesDAO;

        public UI(IDatesDAO datesDAO)
        {
            this.datesDAO = datesDAO;
        }

        public void Run()
        {
            string userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("--Please Select an Option--");
                Console.WriteLine("1) Get a random date idea!");
                Console.WriteLine("2) Get a list of all date ideas");
                Console.WriteLine("3) Add a new date idea");
                Console.WriteLine("4) Get specific date idea by ID");
                Console.WriteLine("5) Mark date completed");
                Console.WriteLine("Exit");
                Console.WriteLine();
                userInput = Console.ReadLine();
                Console.Clear();

                if(userInput == "1")
                {
                    Dates dates = datesDAO.GetRandomDate();
                    Console.WriteLine("Name: " + dates.Name);
                    Console.WriteLine("Description: " + dates.Description);
                    Console.WriteLine("Location: " + dates.Location);
                    if (dates.Link != "")
                    {
                        Console.WriteLine("Link: " + dates.Link);
                    }
                    Console.WriteLine("Added by: " + dates.AddedBy);
                    
                    
                }
                if(userInput == "2")
                {
                    foreach(Dates dates in datesDAO.GetAllDates())
                    {
                        Console.WriteLine("Name: " + dates.Name);
                        Console.WriteLine("Description: " + dates.Description);
                        Console.WriteLine("Location: " + dates.Location);
                        if (dates.Link != "")
                        {
                            Console.WriteLine("Link: " + dates.Link);
                        }
                        Console.WriteLine("Added by: " + dates.AddedBy);
                        Console.WriteLine("Completed: " + dates.Completed);
                        Console.WriteLine();
                    }
                }
                if(userInput == "3")
                {
                    string answer;
                    Dates newDate = new Dates();
                    do
                    {
                        Console.Write("Name: ");
                        newDate.Name = Console.ReadLine();
                        Console.Write("Description: ");
                        newDate.Description = Console.ReadLine();
                        Console.Write("Location: ");
                        newDate.Location = Console.ReadLine();
                        Console.Write("Link (if any): ");
                        newDate.Link = Console.ReadLine();
                        Console.Write("Added By: ");
                        newDate.AddedBy = Console.ReadLine();
                        Console.WriteLine("Does this information look correct?");
                        answer = Console.ReadLine().ToLower().Trim();

                    } while (answer != "yes");
                    Console.WriteLine("Do you want to add this date into the database?");
                    answer = Console.ReadLine();
                    while(answer == "")
                    {
                        Console.WriteLine("Please enter yes or no");
                        answer = Console.ReadLine();
                    }
                    answer = answer.ToLower().Trim();
                    if (answer == "yes")
                    {
                        datesDAO.AddDate(newDate);
                        Console.Clear();
                        Console.WriteLine("Date idea added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Please press enter to return to main menu");
                        Console.ReadLine();
                    }
                }
                if (userInput == "4")
                {
                    foreach  (Dates dates in datesDAO.GetAllDates())
                    {
                        Console.WriteLine("ID: " + dates.DateId);
                        Console.WriteLine("Name: " + dates.Name);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Please select the ID of which date you would like to view.");
                    int dateSelection = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Dates dates1 = datesDAO.DateById(dateSelection);
                    Console.WriteLine("Name: " + dates1.Name);
                    Console.WriteLine("Description: " + dates1.Description);
                    Console.WriteLine("Location: " + dates1.Location);
                    if (dates1.Link != "")
                    {
                        Console.WriteLine("Link: " + dates1.Link);
                    }
                    Console.WriteLine("Added by: " + dates1.AddedBy);
                    Console.WriteLine("Completed: " + dates1.Completed);
                    Console.WriteLine();
                }
                if(userInput == "5")
                {
                    foreach (Dates dates in datesDAO.GetAllDates())
                    {
                        Console.WriteLine("ID: " + dates.DateId);
                        Console.WriteLine("Name: " + dates.Name);
                        Console.WriteLine("Completed: " + dates.Completed);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Please select the ID of which date you would like to mark completed.");
                    int dateSelection = Convert.ToInt32(Console.ReadLine());
                    datesDAO.UpdateCompleteDate(dateSelection);
                    Console.WriteLine("Congradulations on your date!");
                }


                if(userInput.ToLower().Trim() != "exit")
                {
                    Console.WriteLine();
                    Console.Write("Press enter to continue");
                    Console.ReadLine();
                }

            }
            while (userInput.ToLower().Trim() != "exit");
        }
    }
}
