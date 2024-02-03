using System;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public string GetRandomPrompt()
    {
        Random generator = new Random();
        int randomIndex = generator.Next(0, _prompts.Count);
        
        return _prompts[randomIndex];
    }

    public string GetRandomQuestion()
    {
        Random generator = new Random();
        int randomIndex = generator.Next(0, _questions.Count);
        
        return _questions[randomIndex];
    }

    public void DisplayPrompt()
    {
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {randomPrompt} ---");
        Console.WriteLine();
    }

    public void DisplayQuestion()
    {
        string randomQuestion = GetRandomQuestion();
        Console.Write($"> {randomQuestion}");
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        DisplayPrompt();

        Console.WriteLine("When you have something in mind, please press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(3);

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        DateTime currentTime = startTime;

        while (currentTime < endTime)
        {
            DisplayQuestion();
            ShowSpinner(10);
            Console.WriteLine();

            currentTime = DateTime.Now;
        }

        DisplayEndingMessage();
    }
}