using System;
using System.Collections;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Create several string lists for the MenuManager to use:
        List<string> options = new List<string>()
        {
            "Nutrition",
            "Goals",
            "Save",
            "Load",
        };

        List<string> nutritionOptions = new List<string>()
        {
            "Log Macros",
            "Log Calories",
        };

        List<string> goalOptions = new List<string>()
        {
            "View Goals",
            "Log Goal",
            "Create Goal"
        };

        // Initialize all MenuManagers
        MenuManager homeMenu = new MenuManager("Main Menu", options);
        MenuManager nutritionMenu = new MenuManager("Nutritional Menu", nutritionOptions);
        MenuManager goalMenu = new MenuManager("Goal Menu", goalOptions);

        //Initialize Trackers
        DailyCalorieTracker calorieTracker = new DailyCalorieTracker();
        DailyMacroTracker macroTracker = new DailyMacroTracker();

        //Initialize SaveManager and GoalManager
        SaveManager saveManager = new SaveManager();
        GoalManager goalManager = new GoalManager();

        //Start main menu
        OpenMainMenu();

        void OpenMainMenu()
        {
           bool quitMenu = false;

            while (!quitMenu)
            {
                int option = homeMenu.PickOption();

                switch (option)
                {
                    case 1: // Nutrition
                    {
                        OpenNutritionMenu();
                        break;
                    }
                    case 2: // Goals
                    {
                        OpenGoalMenu();
                        break;
                    }
                    case 3: // Save
                    {
                        saveManager = new SaveManager();
                        goalManager.SaveTo(saveManager);
                        saveManager.AddData(macroTracker.GetStringRepresentation());
                        saveManager.AddData(calorieTracker.GetStringRepresentation());
                        saveManager.Save();
                        break;
                    }
                    case 4: // Load
                    {
                        saveManager.Load();
                        LoadData(saveManager.GetData());
                        break;
                    }
                    case 5: // Quit
                    {
                        quitMenu = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please select a valid option.");
                        break;
                    }
                }
           }
        }

        void OpenNutritionMenu()
        {
            bool quitMenu = false;

            while (!quitMenu)
            {
                Console.WriteLine();
                Console.WriteLine(macroTracker.GetDisplayText());
                Console.WriteLine(calorieTracker.GetDisplayText());

                int nutritionOption = nutritionMenu.PickOption();

                switch (nutritionOption)
                {
                    case 1: // Log Macros
                    {
                        macroTracker.Log();
                        break;
                    }
                    case 2: // Log Calories
                    {
                        calorieTracker.Log();
                        break;
                    }
                    case 3: // Quit
                    {
                        quitMenu = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please select a valid option.");
                        break;
                    }
                }
            }
        }

        void OpenGoalMenu()
        {
            bool quitMenu = false;

            while (!quitMenu)
            {
                int goalOption = goalMenu.PickOption();

                switch (goalOption)
                {
                    case 1: // View Goals
                    {
                        goalManager.DisplayGoals();
                        break;
                    }
                    case 2: // Log Goal
                    {   
                        if (goalManager.GetGoals().Count == 0)
                        {
                            Console.WriteLine("You do not currently have any goals to log.");
                        }
                        else
                        {
                            Goal goal = goalManager.PickGoal();
                            goal.Log();
                        }
                        break;
                    }
                    case 3: // Create Goal
                    {
                        Goal goal = goalManager.AddGoal();
                        break;
                    }
                    case 4: // Quit
                    {
                        quitMenu = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please select a valid option.");
                        break;
                    }
                }
            }
        }

        void LoadData(List<String> dataList)
        {
            foreach (string line in dataList)
            {
                string[] lineComponents = line.Split("||");
                string[] data = lineComponents[1].Split("|");

                string dataType = lineComponents[0];

                // Load in the save data and assign the info to their respective classes:
                switch (dataType.ToLower())
                {
                    case "weightgoal":
                    {
                        // Data is saved as: Type||Title|Description|StartingWeight|GoalWeight|CurrentWeight
                        WeightGoal weightGoal = new WeightGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                        goalManager.AddGoal(weightGoal);
                        break;
                    }
                    case "dailygoal":
                    {
                        // Data is saved as: Type||Title|Description|ShortDate|Streak
                        //https://stackoverflow.com/questions/1905850/how-do-i-convert-a-short-date-string-back-to-a-datetime-object
                        DateTime lastEnteredDate = GetReformattedDateTime(data[2]);
                        int streak = int.Parse(data[3]);
                        DailyGoal dailyGoal = new DailyGoal(data[0], data[1], lastEnteredDate, streak);
                        goalManager.AddGoal(dailyGoal);
                        break;
                    }
                    case "generalgoal":
                    {
                        // Data is saved as: Type||Title|Description|IsComplete
                        GeneralGoal generalGoal = new GeneralGoal(data[0], data[1], bool.Parse(data[2]));
                        goalManager.AddGoal(generalGoal);
                        break;
                    }
                    case "macrotracker":
                    {
                        DateTime reformattedDate = GetReformattedDateTime(data[0]);

                        if ((reformattedDate.Date - DateTime.Now.Date).Days == 0)
                        {
                            // Data is saved as: Type||ShortDate|Protein|Carbs|Fat
                            int protein = int.Parse(data[1]);
                            int carbs = int.Parse(data[2]);
                            int fat = int.Parse(data[3]);
                            macroTracker = new DailyMacroTracker(carbs, protein, fat, reformattedDate);
                        }

                        break;
                    }
                    case "calorietracker":
                    {
                        // Data is saved as: Type||ShortDate|Calories
                        DateTime reformattedDate = GetReformattedDateTime(data[0]);

                        if ((reformattedDate.Date - DateTime.Now.Date).Days == 0)
                        {
                            int calories = int.Parse(data[1]);
                            calorieTracker = new DailyCalorieTracker(calories, reformattedDate);
                        }

                        break;
                    }
                }
            }
        }

        DateTime GetReformattedDateTime(string stringDate)
        {
            return DateTime.ParseExact(stringDate, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, null);
        }
    }
}