using System;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    List<string> menuOptions = new List<string>()
    {
        "Create New Goal",
        "List Goals",
        "Save Goals",
        "Load Goals",
        "Record Event",
        "Quit",
    };

    List<Type> goalTypes = new List<Type>()
    {
        typeof(SimpleGoal),
        typeof(EternalGoal),
        typeof(ChecklistGoal),
    };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool done = false;

        while (!done)
        {   
            ListPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options");

            int menuIndex = 1;
            foreach (string option in menuOptions)
            {
                Console.WriteLine($"  {menuIndex}. {option}");
                menuIndex++;
            }

            Console.Write("Select a choice from the menu: ");
            int choiceIndex = int.Parse(Console.ReadLine()) - 1;

            switch (choiceIndex)
            {
                case 0: // Create goal
                    CreateGoal();
                    break;
                case 1: // List Goals
                    ListGoalDetails();
                    break;
                case 2: // Save Goals
                    SaveGoals();
                    break;
                case 3: // Load Goals
                    LoadGoals();
                    break;
                case 4: // Record Event
                    RecordEvent();
                    break;
                case 5: // Quit
                    done = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void ListPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Your goals are:");
        int goalIndex = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($" {goalIndex}. {goal.GetName()}");
            goalIndex++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your goals are:");
        int goalIndex = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($" {goalIndex}. {goal.GetDetailsString()}");
            goalIndex++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        
        int menuIndex = 1;
        foreach (Type goalType in goalTypes)
        {
            Console.WriteLine($"  {menuIndex}. {goalType}");
            menuIndex++;
        }

        Console.Write("Which type of goal would you like to create? ");
        int choiceIndex = int.Parse(Console.ReadLine()) - 1;
        List<Object> goalData;

        switch (choiceIndex)
        {
            case 0: // Simple Goal
                goalData = GetGoalData(false);
                SimpleGoal simpleGoal = new SimpleGoal((string)goalData[0], (string)goalData[1], (int)goalData[2]);
                _goals.Add(simpleGoal);
                break;
            case 1: // Eternal Goal
                goalData = GetGoalData(false);
                EternalGoal eternalGoal = new EternalGoal((string)goalData[0], (string)goalData[1], (int)goalData[2]);
                _goals.Add(eternalGoal);
                break;
            case 2: // Checklist Goal
                goalData = GetGoalData(true);
                ChecklistGoal checklistGoal = new ChecklistGoal((string)goalData[0], (string)goalData[1], (int)goalData[2], (int)goalData[3], (int)goalData[4]);
                _goals.Add(checklistGoal);
                break;
            default:
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];

            if (!goal.IsComplete())
            {
                goal.RecordEvent();
                int points = goal.GetPoints();

                if (goal.IsComplete())
                {
                    points += goal.GetBonus();
                }

                Console.WriteLine($"Congratulations! You have earned {points} points!");
                _score += points;
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        Console.WriteLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentaion());
            }
        }
    }

    public void LoadGoals()
    {
        _goals = new List<Goal>();
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = File.ReadAllLines(fileName);
        Console.WriteLine();

        int lineIndex = 1;
        foreach (string line in lines)
        {
            if (lineIndex == 1)
            {
                string filteredText = line.ToString().Trim().Replace("\n", "");
                _score = int.Parse(filteredText);
            }
            else
            {
                string[] typeData = line.Split(":");
                string goalType = typeData[0];

                string[] classData = typeData[1].Split(",");
                string name = classData[0];
                string description = classData[1];
                int points = int.Parse(classData[2]);

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(classData[3]);
                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (goalType == "ChecklistGoal")
                {
                    int bonus = int.Parse(classData[3]);
                    int target = int.Parse(classData[4]);
                    int amountCompleted = int.Parse(classData[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                }
            }

            lineIndex++;
        }
    }

    static List<Object> GetGoalData(bool hasBonus)
    {
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string goalDesc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());
        
        List<Object> goalData = new List<Object> 
        {
            goalName, 
            goalDesc, 
            goalPoints
        };

        if (hasBonus)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing this goal? ");
            int bonus = int.Parse(Console.ReadLine());

            goalData.Add(target);
            goalData.Add(bonus);
        }

        return goalData;
    }
}