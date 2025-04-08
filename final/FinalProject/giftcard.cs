class Giftcard : Item
{
    private double _balance;
    private bool _reloadable;

    // private string _cardNumber; // random 8 character id

    public Giftcard() : base()
    {

    }
    public Giftcard(string name, double price, double balance, bool reloadable) : base(name, price)
    {
        _balance = balance;
        _reloadable = reloadable;
    }
    public Giftcard(string rep) : base(rep)
    {
        String[] itemRaw = rep.Split("`");

        _balance = Convert.ToDouble(itemRaw[5]);
        _reloadable = Convert.ToBoolean(itemRaw[6]);
    }

    public override void OnScan()
    {
        if(!CanSellCheck())
        {
            System.Console.WriteLine("There is a recall on this item, it cannot be sold.");
            return;
        }

        string balanceInput = "0";

        if (_balance == 0)
        {
            while (balanceInput == "0")
            {
                System.Console.Write("How much would you like to load onto the card? $");
                _balance = Math.Abs(Math.Round(Convert.ToDouble(System.Console.ReadLine()),2));
            }
            _price = _balance;

            _cartPrice = _price;
        }
        else
        {
            _cartPrice = _price;
        }
    }

    public void reload(string cardNumber)
    {
        
    }

    public override string GetRep()
    {
        return $"6`{_name}`{_price}`{_canReturn}`{_recall}`{_balance}`{_reloadable}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice: {_price}\nReturnable: {_canReturn}\nRecall: {_recall}\nBalance: {_balance}\nReloadable: {_reloadable}\n\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }
}