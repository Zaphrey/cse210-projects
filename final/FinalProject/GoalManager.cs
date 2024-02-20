using System;

public class GoalManager
{
    private List<Goal> _goals;

    MenuManager goalMenuManager = new MenuManager("GoalOptions", new List<string>(){
        "Daily Goal",
        "General Goal",
        "Weight Goal",
    });

    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public GoalManager(List<Goal> goals)
    {
        _goals = goals;
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Your current goals:");
        int index = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"  {index}. {goal.GetDisplayText()}");
            index++;
        }
    }

    public Goal PickGoal()
    {
        DisplayGoals();

        Console.Write("Please input a goal from the options above: ");
        return _goals[int.Parse(Console.ReadLine()) - 1];
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public Goal AddGoal()
    {
        int goalOption = goalMenuManager.PickOption();

        Console.Write("Please enter a name: ");
        string title = Console.ReadLine();

        Console.Write("Please enter a description: ");
        string description = Console.ReadLine();

        switch (goalOption)
        {
            case 1:
            {
                DailyGoal dailyGoal = new DailyGoal(title, description);
                _goals.Add(dailyGoal);
                break;
            }
            case 2:
            {   
                GeneralGoal generalGoal = new GeneralGoal(title, description);
                _goals.Add(generalGoal);
                break;
            }
            case 3:
            {
                Console.Write("Please enter a starting weight: ");
                int startingWeight = int.Parse(Console.ReadLine());

                Console.Write("Please enter a goal weight: ");
                int goalWeight = int.Parse(Console.ReadLine());

                WeightGoal weightGoal = new WeightGoal(title, description, startingWeight, goalWeight);
                _goals.Add(weightGoal);

                break;
            }
            default:
            {
                Console.WriteLine("Please select a valid option.");
                break;
            }
        }

        return _goals[_goals.Count - 1];
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RemoveGoal(Goal goal)
    {
        _goals.Remove(goal);
    }

    public void SaveTo(SaveManager manager)
    {
        foreach (Goal goal in _goals)
        {
            manager.AddData(goal.GetStringRepresentation());
        }
    }
}