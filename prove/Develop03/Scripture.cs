using System;
using System.IO;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] textParts = text.Split(" ");

        foreach (string textPart in textParts)
        {
            Word word = new Word(textPart);
            _words.Add(word);
        }
    }

    public void HideRandomWords()
    {
        List<Word> activeWords = new List<Word>();
        Random generator = new Random();
        int hiddenWordCount = 0;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                activeWords.Add(word);
            }
        }

        while (hiddenWordCount < Math.Min(activeWords.Count, 4) && !IsCompletelyHidden())
        {
            int randomInt = generator.Next(0, activeWords.Count);

            if (!activeWords[randomInt].IsHidden())
            {
                activeWords[randomInt].Hide();
                hiddenWordCount++;
            }
        }
    }

    public void ShowAllWords()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                word.Show();
            }
        }
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public string GetBookText()
    {
        return _reference.GetDisplayText();
    }
    public string GetDisplayText()
    {
        string baseString = _reference.GetDisplayText();

        foreach (Word word in _words)
        {
            baseString = $"{baseString} {word.GetDisplayText()}";
        }

        return baseString;
    }
}