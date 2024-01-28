using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();
        Console.WriteLine("Please input a file to load from: ");
        string fileName = Console.ReadLine();

        // Parse each entry within the text file and extract the 
        // book, chapter, startVerse, and endVerse.
        foreach (string line in File.ReadAllLines(fileName))
        {
            string[] parts = line.Split(" ");
            string[] verses = parts[1].Split(":")[1].Split("-");

            string book = parts[0];
            int chapter = int.Parse(parts[1].Split(":")[0]);
            int startVerse = int.Parse(verses[0]);
            int endVerse = 0;

            if (verses.Length > 1)
            {
                endVerse = int.Parse(verses[1]);
            }
            
            // Set the book and chapter/verse strings to blank onesthen merge
            // the parts into a single string which has the start trimmed
            parts[0] = "";
            parts[1] = "";
            
            string text = string.Join(" ", parts).TrimStart();

            Reference reference = new Reference(book, chapter, startVerse, endVerse);
            Scripture scripture = new Scripture(reference, text);

            scriptures.Add(scripture);
        }

        // Start the main loop which asks the user to pick a scripture
        // that has been extracted from the file:
        bool continueMemorizing = true;

        do
        {
            Console.Clear();
            Console.WriteLine("Please enter which scripture would you like to memorize:");
            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetBookText()}");
            }
            
            try
            {
                int choice = int.Parse(Console.ReadLine()) - 1;

                if (scriptures.ElementAtOrDefault(choice) != null)
                {
                    string input = MemorizeScripture(scriptures[choice]);
                    string option = "";

                    if (input != "quit")
                    {
                        Console.WriteLine("Please enter to choose another or type 'quit' to quit:");
                        option = Console.ReadLine();
                    }

                    if (option == "quit" || input == "quit")
                    {
                        continueMemorizing = false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (continueMemorizing);
    }

    static string MemorizeScripture(Scripture scripture)
    {
        string input = "";
        scripture.ShowAllWords();

        while (input != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("");
            Console.WriteLine("Please enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();

            scripture.HideRandomWords();

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("");
            }
        }

        return input;
    }
}