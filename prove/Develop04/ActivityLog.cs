using System;

public class ActivityLog
{
    private string _name;
    private int _count;

    public ActivityLog(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }
    public void AddCount()
    {
        _count++;
    }

    public int GetCount()
    {
        return _count;
    }
}