using System;

public class WeightGoal : Goal
{
    private int _startingWeight;
    private int _goalWeight;
    private int _currentWeight;

    public WeightGoal(string title, string description, int startingWeight, int goalWeight) : base(title, description)
    {
        _startingWeight = startingWeight;
        _goalWeight = goalWeight;
        _currentWeight = startingWeight;
    }

    public WeightGoal(string title, string description, int startingWeight, int goalWeight, int currentWeight) : base(title, description)
    {
        _startingWeight = startingWeight;
        _goalWeight = goalWeight;
        _currentWeight = currentWeight;
    }

    public override void Log()
    {
        Console.Write("What is your current weight in pounds? ");
        int weight = int.Parse(Console.ReadLine());
        
        _currentWeight = weight;
    }

    public override string GetStringRepresentation()
    {
        return $"WeightGoal||{GetTitle()}|{GetDescription()}|{_startingWeight}|{_goalWeight}|{_currentWeight}";
    }

    public override string GetDisplayText()
    {


        string mark = IsComplete() ? "X" : $"{GetPercentage(_currentWeight, _startingWeight, _goalWeight)}%";
        return $"{GetTitle()} - {GetDescription()} [{mark}]";
    }

    public override bool IsComplete()
    {
        if (_currentWeight <= _goalWeight)
        {
            return true;
        }

        return false;
    }

    //https://stackoverflow.com/questions/38549344/javascript-logic-get-percentage-of-each-number-between-two-numbers
    static int GetPercentage(int x, int a, int b)
    {
        return (int)((double)(x - a) / (b - a) * 100);
    }
}