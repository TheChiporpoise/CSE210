class Produce : Food
{
    private double _weightCeil;
    private double _weightFloor;

    private double _weight; // defined when scanned
    
    public Produce() : base()
    {

    }
    public Produce(string name, double pricePerPound, bool canReturn, string expirationDate, string keep, double ceil, double floor) : base(name, pricePerPound, canReturn, expirationDate, keep)
    {
        _weightCeil = ceil;
        _weightFloor = floor;
    }
    public Produce(string rep) : base(rep)
    {
        String[] itemRaw = rep.Split("`");
        
        _weightCeil = Convert.ToDouble(itemRaw[7]);
        _weightFloor = Convert.ToDouble(itemRaw[8]);
    }

    public override void OnScan()
    {
        if(!CanSellCheck())
        {   
            if (_recall)
            {
                System.Console.Write("\nThere is a recall on this item, it cannot be sold. Press ENTER to continue. ");
            }
            else
            {
                System.Console.Write("\nThis item is expired, it cannot be sold.");
            }
            System.Console.ReadLine();
            return;
        }
        
        _weight = -1;
        while (!(_weight <= _weightCeil && _weightFloor <= _weight))
        {
            System.Console.Write("\nEnter weight: ");
            _weight = Convert.ToDouble(System.Console.ReadLine()); // add numeric input validation
        }

        if (_keep != "N/A")
        {
            System.Console.Write($"\nKeep {_keep}. Press ENTER to continue. ");
            System.Console.ReadLine();
        }
        
        _cartPrice = Math.Round(_weight * _price, 2);
    }

    // public override bool CanSellCheck()
    // {
    //     base.CanSellCheck();
    // }

    public override string GetRep()
    {
        return $"2`{_name}`{_price}`{_canReturn}`{_recall}`{_expirationDate}`{_keep}`{_weightCeil}`{_weightFloor}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice per Pound: ${_price:F2}\nReturnable: {_canReturn}\nRecall: {_recall}\nExp Date: {_expirationDate}\nKeep Instructions: {_keep}\nWeight Ceiling: {_weightCeil}\nWeight Floor: {_weightFloor}\n\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }

    public override string ReceiptFormat()
    {
        return $"{_name} {_weight}lbs -- ${_cartPrice:F2}\n\tGood until: {_expirationDate}";
    }
}