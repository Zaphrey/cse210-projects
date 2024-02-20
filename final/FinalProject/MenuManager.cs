using System;

public class MenuManager
{
    private string _title;
    private List<string> _options;

    public MenuManager(string title, List<string> options)
    {
        _title = title;
        _options = options;
    }

    public void AddOption(string option)
    {
        _options.Add(option);
    }

    public void DisplayOptions()
    {
        Console.WriteLine();
        Console.WriteLine(_title);
        int index = 1;

        foreach (string option in _options)
        {
            Console.WriteLine($"  {index}. {option}");
            index++;
        }

        Console.WriteLine($"  {index}. Exit");
    }

    public int PickOption()
    {
        DisplayOptions();
        Console.Write("Select an option from the list above: ");

        while (true)
        {
            try
            {   
                int option = int.Parse(Console.ReadLine());

                // Add 1 to the count to accomodate for the exit option
                if (option >= 1 && option <= _options.Count() + 1)
                {
                    return option;
                }
                else 
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }

    public void SetOptions(List<string> options)
    {
        _options = options;
    }
}