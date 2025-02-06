class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNum)
    {
        _top = wholeNum;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        if (bottom == 0)
        {
            System.Console.WriteLine("Invalid, denominator cannot be 0");
            return;
        }
        _bottom = bottom;
    }

    public String GetFractionString()
    {
        String text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        return Convert.ToDouble(_top) / Convert.ToDouble(_bottom);
    }
}