using System;
using System.Reflection.Metadata.Ecma335;

public class Prompt
{
    Random generator = new Random();
    public List<string> _prompts = new List<string>();

    public string GetRandomPrompt()
    {
        string randomPrompt = _prompts[generator.Next(0, _prompts.Count)];

        return randomPrompt;
    }

    public void AddPrompt(string prompt)
    {
        _prompts.Add(prompt);
    }
}