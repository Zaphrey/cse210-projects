using System;

public class DailyMacroTracker : ITracker
{
    private int _protein;
    private int _carbs;
    private int _fat;
    private DateTime _date;

    public DailyMacroTracker()
    {
        _protein = 0;
        _carbs = 0;
        _fat = 0;
        _date = DateTime.Now;
    }

    public DailyMacroTracker(int protein, int carbs, int fat, DateTime date)
    {
        _protein = protein;
        _carbs = carbs;
        _fat = fat;
        _date = date;
    }

    public string GetDisplayText()
    {
        return $"Your current macros are at: Protein {_protein}g Carbohydrates {_carbs}g Fat {_fat}g";
    }

    public void Log()
    {
        Console.Write("How many grams of protein would you like to log? ");
        int protein = int.Parse(Console.ReadLine());
        Console.Write("How many grams of carbohydrates would you like to log? ");
        int carbs = int.Parse(Console.ReadLine());
        Console.Write("How many grams of fat would you like to log? ");
        int fat = int.Parse(Console.ReadLine());

        _protein += protein;
        _carbs += carbs;
        _fat += fat;
    }

    public string GetStringRepresentation()
    {
        string formattedDate = _date.ToShortDateString();
        return $"MacroTracker||{formattedDate}|{_protein}|{_carbs}|{_fat}";
    }
    public DateTime GetDate()
    {
        return _date;
    }
}