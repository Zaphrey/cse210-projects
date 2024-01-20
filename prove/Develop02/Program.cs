using System;
using System.IO;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        Prompt prompt = new Prompt();
        prompt.AddPrompt("What was the best part of your day?");
        prompt.AddPrompt("Who did you see today?");
        prompt.AddPrompt("What was the worst part of your day?");
        prompt.AddPrompt("What are some skills that I want to develop?");
        prompt.AddPrompt("What inspires me?");

        int option = 0;

        while (option != 5)
        {
            Console.WriteLine("\nPlease select one of the following: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.WriteLine();
                string randomPrompt = prompt.GetRandomPrompt();
                Console.WriteLine(randomPrompt);

                string journalEntry = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._prompt = randomPrompt ;
                entry._journalEntry = journalEntry;
            
                journal.AddEntry(entry);
            }
            else if (option == 2)
            {
                journal.DisplayEntries();
            }
            else if (option == 3)
            {
                Console.WriteLine("What is the file name? ");
                string fileName = Console.ReadLine();
                
                journal.LoadEntries(fileName);
            }
            else if (option == 4)
            {
                Console.WriteLine("What is the file name? ");
                string fileName = Console.ReadLine();

                journal.SaveEntries(fileName);
            }
        }
    }
}