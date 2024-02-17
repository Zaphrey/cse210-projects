using System;

public class GoalManager
{
    private List<Goal> _goals;

    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public GoalManager(List<Goal> goals)
    {
        _goals = goals;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RemoveGoal(Goal goal)
    {
        _goals.Remove(goal);
    }
}