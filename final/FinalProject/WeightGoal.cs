using System;

public class WeightGoal : Goal
{
    private int _startingWeight;
    private int _goalWeight;
    private List<int> _checkpoints;

    public WeightGoal(string title, string description, int startingWeight, int goalWeight) : base(title, description)
    {
        _startingWeight = startingWeight;
        _goalWeight = goalWeight;
        _checkpoints = new List<int>();
    }

    public WeightGoal(string title, string description, int startingWeight, int goalWeight, List<int> checkpoints) : base(title, description)
    {
        _startingWeight = startingWeight;
        _goalWeight = goalWeight;
        _checkpoints = checkpoints;
    }

    public override void Log()
    {
        Console.Write("What is your current weight in pounds? ");
        int weight = int.Parse(Console.ReadLine());
        
        _checkpoints.Add(weight);
    }

    public override string GetStringRepresentation()
    {
        string initialFormat = $"WeightGoal|{GetTitle()}|{GetDescription()}|{_startingWeight}|{_goalWeight}|{IsComplete()}|";

        foreach (int weightCheckpoint in _checkpoints)
        {
            initialFormat = $"{initialFormat}{weightCheckpoint}|";
        }

        return initialFormat;
    }

    public override bool IsComplete()
    {
        if (_checkpoints.Count > 1)
        {
            int lastWeight = _checkpoints[_checkpoints.Count - 1];

            if (lastWeight <= _goalWeight)
            {
                return true;
            }
        }

        return false;
    }
}