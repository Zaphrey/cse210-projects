using System;

public class DailyGoal : Goal
{

    public DailyGoal(string title, string description) : base(title, description)
    {

    }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }

    public override void Log()
    {
        
    }

    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }
}