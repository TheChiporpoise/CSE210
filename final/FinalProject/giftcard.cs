class Giftcard : Item
{
    private double _balance;
    private bool _reloadable;

    private string _cardNumber; // random 8 character id

    public Giftcard() : base()
    {
        
    }
    public Giftcard(string name, float price, bool canReturn, double balance, bool reloadable) : base(name, price, canReturn)
    {
        _balance = balance;
        _reloadable = reloadable;
    }

    protected override void OnScan()
    {
        throw new NotImplementedException();
    }

    private void reload(string cardNumber)
    {
        
    }
}