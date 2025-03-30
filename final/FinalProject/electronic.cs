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
    public Electronic(string name, float price, bool canReturn, double warrantyPrice, int warrantyDuration, string warrantyDescription) : base(name, price, canReturn)
    {
        _warrantyPrice = warrantyPrice;
        _warrantyDuration = warrantyDuration;
        _warrantyDescription = warrantyDescription;   
    }

    protected override void OnScan()
    {
        throw new NotImplementedException();
    }

    private void WarrantyOffer()
    {
        
    }
}