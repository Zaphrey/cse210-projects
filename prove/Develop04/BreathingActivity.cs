using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        int inhaleDuration = 4;
        int exhaleDuration = 6;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        DateTime currentTime = startTime;

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        while (currentTime < endTime)
        {
            currentTime = DateTime.Now;

            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountdown(inhaleDuration);

            Console.WriteLine();

            Console.Write("Now breathe out...");
            ShowCountdown(exhaleDuration);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}