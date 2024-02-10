using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _bonus = bonus;
        _target = target;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _bonus = bonus;
        _target = target;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        bool isComplete = (_amountCompleted >= _target) ? true : false;
        return isComplete;
    }

    public override string GetDetailsString()
    {
        string filler = IsComplete() ? "X" : " ";
        return $"[{filler}] {GetName()} ({GetDescription()}) - Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentaion()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }

    public override int GetBonus()
    {
        return _bonus;
    }
}