using System.Linq.Expressions;

class Clothing : Item
{
    private List<string> _sizeNames = new List<string>(); // all size names
    private double _percentAdd; // determines added price based on _sizeIndex

    private string _sizeNameString = ""; // used to display size options in OnScan()
    private int _sizeIndex; // determined at checkout
    
    public Clothing() : base()
    {
        
    }
    public Clothing(string name, double price, bool canReturn, int sizesCount, double percentAdd) : base(name, price, canReturn)
    {
        string currentName;
        for (int i = 0; i < sizesCount; i++)
        {
            System.Console.Write($"What is the name of the #{i + 1} size? ");
            currentName = System.Console.ReadLine();
            _sizeNames.Add(currentName);
            _sizeNameString += $"\n[{i + 1}] {currentName}";
        }
        _percentAdd = percentAdd;
    }
    public Clothing(string rep) : base(rep)
    {
        String[] itemRaw = rep.Split("`");

        _sizeNames = new List<string>(itemRaw[5].Split(",")); // says some of declaration is unnecessary, but doesn't work without it
        for (int i = 0; i < _sizeNames.Count(); i++)
        {
            _sizeNameString += $"\n[{i + 1}] {_sizeNames[i]}";
        }
        _percentAdd = Convert.ToDouble(itemRaw[6]);
    }

    public override void OnScan()
    {
        if(!CanSellCheck())
        {
            System.Console.WriteLine("There is a recall on this item, it cannot be sold.");
            return;
        }
        
        while (!(_sizeIndex <= _sizeNames.Count && 0 <= _sizeIndex))
        {
            System.Console.WriteLine($"Select from the following sizes: {_sizeNameString}");
            try
            {
                _sizeIndex = Convert.ToInt32(System.Console.ReadLine()) - 1;
            }
            catch
            {
                System.Console.Write("That size is not listed, Press ENTER to continue, then try again.");
                System.Console.ReadLine();
            }
        }

        _cartPrice = Math.Round(_price * (1 + (_sizeIndex * _percentAdd)));
    }

    public override string GetRep()
    {
        return $"3`{_name}`{_price}`{_canReturn}`{_recall}`{string.Join(",", _sizeNames)}`{_percentAdd}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.Clear();
        System.Console.Write($"Name: {_name}\nPrice: ${_price}\nReturnable: {_canReturn}\nRecall: {_recall}\n{_sizeNames.Count()} Sizes: {string.Join(", ", _sizeNames)}\nSize price added: {_percentAdd * 100}% per size up\n\nPress ENTER to continue. ");
        System.Console.ReadLine();
    }
}