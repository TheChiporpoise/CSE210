class Electronic : Item
{
    private double _warrantyPrice;
    private int _warrantyDuration; // days active
    private string _warrantyDescription;

    private int _warrantyNumber = 0; // iterated for each time sold, differentiates from each customer
    private DateOnly _warrantyExpiration; // calculated at checkout

    public Electronic() : base()
    {
        
    }
    public Electronic(string name, double price, bool canReturn, double warrantyPrice, int warrantyDuration, string warrantyDescription) : base(name, price, canReturn)
    {
        _warrantyPrice = warrantyPrice;
        _warrantyDuration = warrantyDuration;
        _warrantyDescription = warrantyDescription;   
    }

    public override void OnScan()
    {
        
    }

    public void WarrantyOffer()
    {
        
    }

    public override string GetRep()
    {
        throw new NotImplementedException();
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice: {_price}\nReturnable: {_canReturn}\nRecall: {_recall}\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }
}