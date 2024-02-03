using System;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    public ListingActivity(string name, string description, List<string> prompts) : base(name, description)
    {
        _prompts = prompts;
    }

    public string GetRandomPrompt()
    {
        Random generator = new Random();
        int randomIndex = generator.Next(0, _prompts.Count);
        
        return _prompts[randomIndex];
    }

    public List<string> GetListFromUser()
    {
        return _prompts;
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(3);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        DateTime currentTime = startTime;

        do
        {
            Console.Write("> ");
            Console.ReadLine();

            _count++;
            currentTime = DateTime.Now;
        }
        while (currentTime < endTime);

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
}