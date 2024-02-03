using System;

class Program
{
    static void Main(string[] args)
    {
        // For the stretch challenge I chose to choose the log suggestion.
        // At the bottom is the function that I created for displaying the log,
        // and I also created a class named "Activity Log" for keeping track of each log.
        
        List<string> listingPrompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"   
        };

        List<string> reflectionPrompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };

        List<string> reflectionQuestions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };

        string listingDesc = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        string reflectionDesc = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        string breathingDesc = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

        ListingActivity listingActivity = new ListingActivity("Listing", listingDesc, listingPrompts);
        ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", reflectionDesc, reflectionPrompts, reflectionQuestions);
        BreathingActivity breathingActivity = new BreathingActivity("Breathing", breathingDesc);

        List<Activity> activities = new List<Activity>()
        {
            listingActivity,
            reflectionActivity,
            breathingActivity
        };

        List<ActivityLog> activityLog = new List<ActivityLog>();

        foreach (Activity activity in activities)
        {
            string activityName = activity.GetName();
            activityLog.Add(new ActivityLog(activityName));
        }

        int selection = 0;
        int lastSelection = activities.Count() + 1;

        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");

            for (int i = 0; i < activities.Count(); i++)
            {
                Console.WriteLine($"   {i + 1}. {activities[i].GetName()} Activity");
            }

            Console.WriteLine($"   {lastSelection}. View Log");
            Console.WriteLine($"   {lastSelection + 1}. Quit");
            Console.Write("Select a choice from the menu: ");
            
            try
            {
                selection = int.Parse(Console.ReadLine()) - 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            if (selection != lastSelection && selection <= activities.Count - 1 && selection >= 0)
            {
                activityLog[selection].AddCount();

                if (activities[selection].GetType() == typeof(BreathingActivity))
                {
                    ((BreathingActivity)activities[selection]).Run();
                }
                else if (activities[selection].GetType() == typeof(ReflectionActivity))
                {
                    ((ReflectionActivity)activities[selection]).Run();
                }
                else if (activities[selection].GetType() == typeof(ListingActivity))
                {
                    ((ListingActivity)activities[selection]).Run();
                }
            }
            else if (selection == lastSelection - 1)
            {
                DisplayLog(activityLog);
            }
        }
        while (selection != lastSelection);
    }

    static void DisplayLog(List<ActivityLog> activityLog)
    {
        int index = 0;
        Console.Clear();
        Console.WriteLine("Here's a log for each time you've completed each activity: ");
        foreach (ActivityLog log in activityLog)
        {
            Console.WriteLine($"   {index + 1}. {log.GetName()}: {log.GetCount()}");
            index++;
        }

        // Display log for only 10 seconds:
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(10);
        DateTime currentTime = DateTime.Now;

        char[] spinnerParts = {'/', '-', '\\', '|'};
        int charIndex = 0;

        while (currentTime < endTime)
        {
            Console.Write(spinnerParts[charIndex]);
            charIndex = (charIndex + 1) % spinnerParts.Length;
            currentTime = DateTime.Now;

            Thread.Sleep(250);
            Console.Write("\b \b");
        } 
    }
}