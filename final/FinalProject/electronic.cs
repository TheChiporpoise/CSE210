class Electronic : Item
{
    private double _warrantyPrice;
    private int _warrantyDuration; // days active
    private string _warrantyDescription;

    // private int _warrantyNumber = 0; // iterated for each time sold, differentiates from each customer
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
    public Electronic(string rep) : base(rep)
    {
        String[] itemRaw = rep.Split("`");

        _warrantyPrice = Convert.ToDouble(itemRaw[5]);
        _warrantyDuration = Convert.ToInt32(itemRaw[6]);
        _warrantyDescription = itemRaw[7];   
    }

    public override void OnScan()
    {
        if(!CanSellCheck())
        {
            System.Console.WriteLine("There is a recall on this item, it cannot be sold.");
            return;
        }

        string yesNo;

        System.Console.Write($"Would you like to purchase a warranty for this {_name}? [Y/N]");
        yesNo = System.Console.ReadLine();
        if (yesNo.ToLower() == "y")
        {
            _warrantyExpiration = DateOnly.FromDateTime(DateTime.Now).AddDays(_warrantyDuration);
            _cartPrice += _warrantyPrice;
        }

        _cartPrice += _price;
    }

    public override string GetRep()
    {
        return $"4`{_name}`{_price}`{_canReturn}`{_recall}`{_warrantyPrice}`{_warrantyDuration}`{_warrantyDescription}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice: {_price}\nReturnable: {_canReturn}\nRecall: {_recall}\nWarranty Price: {_warrantyPrice}\nDuration: {_warrantyDuration} days\nWarranty Description: {_warrantyDescription}\n\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }
}