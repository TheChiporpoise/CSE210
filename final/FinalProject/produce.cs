class Produce : Food
{
    private double _weightCeil;
    private double _weightFloor;

    private double _weight; // defined when scanned
    
    public Produce() : base()
    {

    }
    public Produce(string name, double pricePerPound, bool canReturn, string expirationDate, float ceil, float floor) : base(name, pricePerPound, canReturn, expirationDate)
    {
        _weightCeil = ceil;
        _weightFloor = floor;

    }
    public Produce(string name, double pricePerPound, bool canReturn, string expirationDate, string keep, float ceil, float floor) : base(name, pricePerPound, canReturn, expirationDate, keep)
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
        while (!(_weight <= _weightCeil && _weightFloor <= _weight))
        {
            System.Console.Write("Enter weight: ");
            _weight = Convert.ToDouble(System.Console.ReadLine()); // add numeric input validation
        }
        
        _cartPrice = Math.Round(_weight * _price, 2);
    }

    public override string GetRep()
    {
        return $"1`{_name}`{_price}`{_canReturn}`{_recall}`{_expirationDate}`{_keep}`{_weightCeil}`{_weightFloor}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice per Pound: {_price}\nReturnable: {_canReturn}\nRecall: {_recall}\nExp Date: {_expirationDate}\nKeep Instructions: {_keep}\nWeight Ceiling: {_weightCeil}\nWeight Floor: {_weightFloor}\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }
}