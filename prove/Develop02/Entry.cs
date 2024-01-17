using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _journalEntry;

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt} \n{_journalEntry}");
    }

    public void AddEntry(string prompt, string entry)
    {
        _date = DateTime.Now.ToShortDateString();
        _prompt = prompt;
        _journalEntry = entry;
    }
}