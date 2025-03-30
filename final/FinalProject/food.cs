abstract class Food : Item
{
    protected DateOnly _expirationDate;
    protected string _keep; // temperature/environment

    public Food() : base()
    {
        _expirationDate = new DateOnly();
        _keep = "N/A";
    }
    public Food(string name, float price, bool canReturn, string expirationDate) : base(name, price, canReturn)
    {
        _expirationDate = DateOnly.ParseExact(expirationDate, "MM/dd/yyyy", null);
        _keep = "No instructions for what environment to store this item.";
    }
    public Food(string name, float price, bool canReturn, string expirationDate, string keep) : base(name, price, canReturn)
    {
        _expirationDate = DateOnly.ParseExact(expirationDate, "MM/dd/yyyy", null);
        _keep = keep;
    }

    protected bool IsExpired()
    {
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        if (_expirationDate <= currentDate)
        {
            return true;
        }
        return false;
    }

    protected override void OnScan()
    {
        System.Console.WriteLine(_keep);
    }
    
    protected override bool CanSellCheck()
    {
        if (!(_recall || IsExpired()))
        {
            return false;
        }
        return true;
    }
}