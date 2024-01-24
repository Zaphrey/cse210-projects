using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction (int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Create getter/setter methods for the numerator:
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Create getter/setter methods for the denominator:
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Create retrieval methods for fraction and decimal representations
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        double fractionValue = (double)_top / _bottom;
        return fractionValue;
    }
}