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
    public Item(string name, double price)
    {
        _name = name;
        _price = price;
        _canReturn = true;
    }
    public Item(string name, double price, bool canReturn)
    {
        _name = name;
        _price = price;
        _canReturn = canReturn;
    }
    public Item(string rep)
    {
        String[] itemRaw = rep.Split("`");
        _name = itemRaw[1]; // skips index 0, as that denotes which type the goal is
        _price = Convert.ToDouble(itemRaw[2]);
        _canReturn = Convert.ToBoolean(itemRaw[3]);
        _recall = Convert.ToBoolean(itemRaw[4]);
    }

    public virtual bool CanSellCheck()
    {
        if (_recall)
        {
            return false;
        }
        return true;
    }

    public abstract void OnScan();

    public abstract string GetRep();

    public abstract void Display();

    // getters & setters for basic attributes
    public string GetName()
    {
        return _name;
    }

    public double getCartPrice()
    {
        return _cartPrice;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetPrice(double price)
    {
        _price = price;
    }

    public void SetCanReturn()
    {
        _canReturn = !_canReturn;
    }

    public void SetRecall()
    {
        _recall = !_recall;
    }
}