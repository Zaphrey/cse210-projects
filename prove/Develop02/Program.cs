using System;
using System.IO;

class Program
{
    static void Main()
    {
        List<Entry> entries = new List<Entry>();

        Prompt prompt = new Prompt();
        prompt.AddPrompt("What was the best part of your day?");
        prompt.AddPrompt("Who did you see today?");
        prompt.AddPrompt("What was the worst part of your day?");
        prompt.AddPrompt("What are some skills that I want to develop?");
        prompt.AddPrompt("What inspires me?");

        int option = 0;

        while (option != 5)
        {
            Console.WriteLine("Please select one of the following: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                string randomPrompt = prompt.GetRandomPrompt();
                Console.WriteLine(randomPrompt);

                string journalEntry = Console.ReadLine();

                Entry entry = new Entry();
                entry.AddEntry(randomPrompt, journalEntry);
                entries.Add(entry);
            }
            else if (option == 2)
            {
                foreach (Entry entry in entries)
                {
                    Console.WriteLine("");
                    entry.DisplayEntry();
                }
            }
            else if (option == 3)
            {
                entries = new List<Entry>();

                Console.WriteLine("What is the file name? ");
                string fileName = Console.ReadLine();
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");

                    string loadedDate = parts[0];
                    string loadedPrompt = parts[1];
                    string loadedEntry = parts[2];

                    Entry entry = new Entry();
                    entry._date = loadedDate.TrimStart().Replace("\"", "");
                    entry._prompt = loadedPrompt.TrimStart().Replace("\"", "");
                    entry._journalEntry = loadedEntry.TrimStart().Replace("\"", "");

                    entries.Add(entry);
                }
            }
            else if (option == 4)
            {
                Console.WriteLine("What is the file name? ");
                string fileName = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    foreach (Entry entry in entries){
                        outputFile.WriteLine($"{entry._date}, \"{entry._prompt}\", \"{entry._journalEntry}\"");
                    }
                }
            }
        }
    }
}