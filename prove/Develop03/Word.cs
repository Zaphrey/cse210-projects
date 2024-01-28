using System;
using System.Dynamic;

public class Word
{
    private string _text;
    private bool _isHidden = false;

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            char charToRepear = '_';
            string hiddenWord = new string(charToRepear, _text.Length);

            return hiddenWord;
        }
        else
        {
            return _text;
        }
    }
}