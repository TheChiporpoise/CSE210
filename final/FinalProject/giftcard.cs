class Giftcard : Item
{
    private double _balance;
    private bool _reloadable;

    private string _cardNumber; // random 8 character id

    public Giftcard() : base()
    {
        
    }
    public Giftcard(string name, double price, bool canReturn, double balance, bool reloadable) : base(name, price, canReturn)
    {
        _balance = balance;
        _reloadable = reloadable;
    }

    public override void OnScan()
    {
        throw new NotImplementedException();
    }

    public void reload(string cardNumber)
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