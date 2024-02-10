using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name ,description, points)
    {

    }

    public override void RecordEvent()
    {
        
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentaion()
    {
        return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
    }
}