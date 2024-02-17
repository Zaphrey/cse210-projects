using System;

public class GeneralGoal : Goal
{

    public GeneralGoal(string title, string description) : base(title, description)
    {

    }
    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }

    public override void Log()
    {
        throw new NotImplementedException();
    }

    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }
}