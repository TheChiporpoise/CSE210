abstract class Item
{
    protected string _name;
    protected double _price; // base price of item used to calculate _cartPrice, however modified
    protected bool _canReturn;
    
    protected bool _recall = false; // never created with recall being true, it is set later
    protected double _cartPrice;

    public Item()
    {
        _name = "N/A";
        _price = 0;
        _canReturn = false;
    }
    public Item(string name, float price)
    {
        _name = name;
        _price = price;
        _canReturn = true;
    }
    public Item(string name, float price, bool canReturn)
    {
        _name = name;
        _price = price;
        _canReturn = canReturn;
    }

    private void SetRecall()
    {
        _recall = !_recall;
    }

    protected abstract void OnScan();

    protected virtual bool CanSellCheck()
    {
        if (_recall)
        {
            return false;
        }
        return true;
    }
}