using System;

public class DailyCalorieTracker : ITracker
{
    private int _calories;
    private DateTime _date;

    public DailyCalorieTracker()
    {
        _calories = 0;
        _date = DateTime.Now;
    }

    public DailyCalorieTracker(int calories, DateTime date)
    {
        _calories = calories;
        _date = date;
    }

    public string GetDisplayText()
    {
        return $"Your current calories are at: {_calories}cal";
    }

    public void Log()
    {
        Console.Write("How many calories would you like to log? ");
        int calories = int.Parse(Console.ReadLine());

        _calories += calories;
    }

    public string GetStringRepresentation()
    {
        string formattedDate = _date.ToShortDateString();
        return $"CalorieTracker||{formattedDate}|{_calories}";
    }

    public DateTime GetDate()
    {
        return _date;
    }
}