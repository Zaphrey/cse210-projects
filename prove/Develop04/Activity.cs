using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    // Not sure if I should be setting the duration here because
    // the duration attribute doesn't seem to be tied to the 
    // Activity constructor.
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public string GetName()
    {
        return _name;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session? ");

        _duration = int.Parse(Console.ReadLine());
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(4);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        DateTime currentTime = DateTime.Now;

        char[] spinnerParts = {'/', '-', '\\', '|'};
        int charIndex = 0;

        while (currentTime < endTime)
        {
            Console.Write(spinnerParts[charIndex]);
            charIndex = (charIndex + 1) % spinnerParts.Length;
            currentTime = DateTime.Now;

            Thread.Sleep(250);
            Console.Write("\b \b");
        } 
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}