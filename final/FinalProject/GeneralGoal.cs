using System;

public class GeneralGoal : Goal
{
    private bool _isComplete;

    public GeneralGoal(string title, string description) : base(title, description)
    {
        _isComplete = false;
    }

    public GeneralGoal(string title, string description, bool isComplete) : base(title, description)
    {
        _isComplete = isComplete;
    }
    public override string GetStringRepresentation()
    {
        return $"GeneralGoal||{GetTitle()}|{GetDescription()}|{_isComplete}";
    }

    public override void Log()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}