class Produce : Food
{
    private double _weightCeil;
    private double _weightFloor;

    private double _weight; // defined when scanned
    
    public Produce() : base()
    {

    }
    public Produce(string name, float pricePerPound, bool canReturn, string expirationDate, float ceil, float floor) : base(name, pricePerPound, canReturn, expirationDate)
    {
        _weightCeil = ceil;
        _weightFloor = floor;

    }
    public Produce(string name, float pricePerPound, bool canReturn, string expirationDate, string keep, float ceil, float floor) : base(name, pricePerPound, canReturn, expirationDate, keep)
    {
        _weightCeil = ceil;
        _weightFloor = floor;
    }

    protected override void OnScan()
    {
        while (!(_weight <= _weightCeil && _weightFloor <= _weight))
        {
            System.Console.Write("Enter weight: ");
            _weight = Convert.ToDouble(System.Console.ReadLine()); // add numeric input validation
        }
        
        _cartPrice = Math.Round(_weight * _price, 2);
    }
}