using System;
using System.IO;

public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine("");
            entry.DisplayEntry();
        }
    }

    public void SaveEntries(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries){
                outputFile.WriteLine($"{entry._date}, \"{entry._prompt}\", \"{entry._journalEntry}\"");
            }
        }
    }

    public void LoadEntries(string fileName)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string loadedDate = parts[0];
            string loadedPrompt = parts[1];
            string loadedEntry = parts[2];

            Entry entry = new Entry();
            entry._date = loadedDate.TrimStart().Replace("\"", "");
            entry._prompt = loadedPrompt.TrimStart().Replace("\"", "");
            entry._journalEntry = loadedEntry.TrimStart().Replace("\"", "");

            _entries.Add(entry);
        }
    }
}
