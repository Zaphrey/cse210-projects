using System;

public class DailyGoal : Goal
{
    private DateTime _date;
    private DateTime _lastEnteredDate;
    private int _streak;

    public DailyGoal(string title, string description) : base(title, description)
    {
        _date = DateTime.Now;
        _lastEnteredDate = _date.AddDays(-1);
        _streak = 0;
    }

    public DailyGoal(string title, string description, DateTime lastEnteredDate) : base(title, description)
    {
        _date = DateTime.Now;
        _lastEnteredDate = lastEnteredDate;
        _streak = 0;
    }

    public DailyGoal(string title, string description, DateTime lastEnteredDate, int streak) : base(title, description)
    {
        _date = DateTime.Now;
        _lastEnteredDate = lastEnteredDate;
        _streak = streak;
    }

    public override string GetStringRepresentation()
    {
        string formattedLastDate = _lastEnteredDate.ToShortDateString();
        return $"DailyGoal||{GetTitle()}|{GetDescription()}|{formattedLastDate}|{_streak}";
    }

    public override void Log()
    {
        //Compare the days between the current date and last entered date.
        //If the days between are equal to 1 then increment the streak up.
        //If the days between are greater than 1 then set the streak to 0.

        //I had to look up how to get the difference between dates and this is the source that helped me:
        //https://stackoverflow.com/questions/1607336/how-to-calculate-difference-between-two-dates-number-of-days
        if ((_date.Date - _lastEnteredDate.Date).Days == 1)
        {
            _streak++;
        }
        else if ((_date.Date - _lastEnteredDate.Date).Days > 1)
        {
            _streak = 0;
        }

        _lastEnteredDate = DateTime.Now;
    }

    public override string GetDisplayText()
    {
        char mark = IsComplete() ? 'X' : ' ';
        return $"{GetTitle()} - {GetDescription()} [{mark}] - Streak: {_streak} days";
    }

    public override bool IsComplete()
    {
        if ((_date.Date - _lastEnteredDate.Date).Days == 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}