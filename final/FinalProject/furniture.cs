class Furniture : Item
{
    private double _deliveryFee;
    private bool _teamCarry; // should customer be prompted asking if they would like help carrying item out

    public Furniture() : base()
    {
        
    }
    public Furniture(string name, double price, bool canReturn, double deliveryFee, bool teamCarry) : base(name, price, canReturn)
    {
        _deliveryFee = deliveryFee;
        _teamCarry = teamCarry;
    }
    public Furniture(string rep) : base(rep)
    {
        String[] itemRaw = rep.Split("`");

        _deliveryFee = Convert.ToDouble(itemRaw[5]);
        _teamCarry = Convert.ToBoolean(itemRaw[6]);
    }

    public override void OnScan()
    {
        if(!CanSellCheck())
        {
            System.Console.Write("\nThere is a recall on this item, it cannot be sold. Press ENTER to continue. ");
            System.Console.ReadLine();
            return;
        }

        string yesNo;

        if (_deliveryFee != 0)
        {
            System.Console.Write("\nWould you like to ship this {_name} home for ${_deliveryFee}? [Y/N] ");
            yesNo = System.Console.ReadLine();
            if (yesNo.ToLower() == "y")
            {
                _cartPrice += _deliveryFee;

                System.Console.WriteLine("\nOf course! We will notify a teammember and your item will be delivered later today.");

                // code to prompt a team member for assistance if integrated into larger network
            }
            else if (_teamCarry)
            {
                System.Console.Write("\nWould you like assistance bringing this {_name} outside? [Y/N] ");
                yesNo = System.Console.ReadLine();
                if (yesNo.ToLower() == "y")
                {
                    System.Console.WriteLine("\nOf course! We will notify a teammember that you need assistance.");

                    // code to prompt a team member for assistance if integrated into larger network
                }
            }
        }

        _cartPrice += _price;

        _cartPrice = Math.Round(_cartPrice,2);
    }

    public override string GetRep()
    {
        return $"5`{_name}`{_price}`{_canReturn}`{_recall}`{_deliveryFee}`{_teamCarry}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice: {_price:F2}\nReturnable: {_canReturn}\nRecall: {_recall}\nDelivery Fee: {_deliveryFee}\nRequires team carry: {_teamCarry}\n\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }

    public override string ReceiptFormat()
    {
        if (_cartPrice != _price)
        {
            return $"{_name} -- ${_price:F2}\n\tDelivery fee -- ${_deliveryFee:F2}";
        }
        else
        {
            return $"{_name} -- ${_price:F2}";
        }
    }
}