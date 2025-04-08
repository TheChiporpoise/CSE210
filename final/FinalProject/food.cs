class Food : Item
{
    protected DateOnly _expirationDate;
    protected string _keep; // temperature/environment

    public Food() : base()
    {
        _expirationDate = new DateOnly();
        _keep = "N/A";
    }
    public Food(string name, double price, bool canReturn, string expirationDate, string keep) : base(name, price, canReturn)
    {
        string[] formats = ["M/dd/yyyy", "M/d/yyyy", "MM/dd/yyyy", "MM/d/yyyy"];
        
        DateOnly.TryParseExact(expirationDate, formats, null, System.Globalization.DateTimeStyles.None, out _expirationDate);
        _keep = keep;
    }
    public Food(string rep) : base(rep)
    {
        String[] itemRaw = rep.Split("`");
        string[] formats = ["M/dd/yyyy", "M/d/yyyy", "MM/dd/yyyy", "MM/d/yyyy"];

        DateOnly.TryParseExact(itemRaw[5], formats, null, System.Globalization.DateTimeStyles.None, out _expirationDate);
        
        _keep = itemRaw[6];
    }

    public bool IsExpired()
    {
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        if (_expirationDate <= currentDate)
        {
            return true;
        }
        return false;
    }

    public override bool CanSellCheck()
    {
        if (!(_recall || IsExpired()))
        {
            return false;
        }
        return true;
    }

    public override void OnScan()
    {
        if(!CanSellCheck())
        {   
            if (_recall)
            {
                System.Console.WriteLine("\nThere is a recall on this item, it cannot be sold.");
            }
            else
            {
                System.Console.WriteLine("\nThis item is expired, it cannot be sold.");
            }
            return;
        }
        
        if (_keep != "N/A")
        {
            System.Console.Write($"Keep {_keep}. Press ENTER to continue. ");
            System.Console.ReadLine();
        }

        _cartPrice = Math.Round(_price,2);
    }

    public override string GetRep()
    {
        return $"1`{_name}`{_price}`{_canReturn}`{_recall}`{_expirationDate}`{_keep}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice: ${_price}\nReturnable: {_canReturn}\nRecall: {_recall}\nExp Date: {_expirationDate}\nKeep Instructions: {_keep}\n\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }
}