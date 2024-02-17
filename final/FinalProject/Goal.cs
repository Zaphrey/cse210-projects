using System;

public abstract class Goal
{
    private string _title;
    private string _description;

    public Goal(string title, string description)
    {
        _title = title;
        _description = description;
    }

    public abstract string GetStringRepresentation();

    public abstract void Log();

    public abstract bool IsComplete();

    public virtual string GetDisplayText()
    {
        return $"{_title} - {_description} | {IsComplete()}";
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetDescription()
    {
        return _description;
    }
}