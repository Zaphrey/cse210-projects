using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> options = new List<string>()
        {
            "View Nutrition",
            "View Goals",
            "Save Data",
            "Load Data",
        };

        List<string> nutritionOptions = new List<string>()
        {
            "Log Macros",
            "Log Calories",
        };

        List<string> goalOptions = new List<string>()
        {
            "View Goals",
            "Log Goal"
        };

        MenuManager homeMenu = new MenuManager("Main Menu", options);
        MenuManager nutritionMenu = new MenuManager("Nutritional Menu", nutritionOptions);
        MenuManager goalMenu = new MenuManager("Goal Menu", goalOptions);

        DailyCalorieTracker calorieTracker = new DailyCalorieTracker();
        DailyMacroTracker macroTracker = new DailyMacroTracker();

        OpenMainMenu();

        void OpenMainMenu()
        {
           bool quitMenu = false;

           while (!quitMenu)
           {
                int option = homeMenu.PickOption();
                Console.WriteLine(option);

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
                        break;
                    }
                    case 4: // Load
                    {
                        break;
                    }
                    case 5: // Quit
                    {
                        quitMenu = true;
                        break;
                    }
                    default:
                    {
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
                Console.WriteLine();

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
                        break;
                    }
                    case 2: // Log Goal
                    {
                        break;
                    }
                    case 3: // Quit
                    {
                        quitMenu = true;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }
    }
}