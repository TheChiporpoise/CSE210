using System.Linq.Expressions;

class Clothing : Item
{
    private List<string> _sizeNames; // all size names
    private string _sizeNameString = ""; // used to display size options in OnScan()
    private LambdaExpression _priceOffset; // determines price based on _sizeIndex, might have to simplify

    private int _sizeIndex; // determined at checkout
    
    public Clothing() : base()
    {
        
    }
    public Clothing(string name, float price, bool canReturn, int sizesCount/*, LambdaExpression offset*/) : base(name, price, canReturn)
    {
        string currentName;
        for (int i = 0; i < sizesCount; i++)
        {
            System.Console.Write($"What is the name of the #{i} size? ");
            currentName = System.Console.ReadLine();
            _sizeNames.Add(currentName);
            _sizeNameString += ($"\n[{i+1}] {currentName}");
        }
    }

    protected override void OnScan()
    {
        while (!(_sizeIndex <= _sizeNames.Count && 0 <= _sizeIndex))
        {
            System.Console.WriteLine($"Select from the following sizes: {_sizeNameString}");
            _sizeIndex = Convert.ToInt32(System.Console.ReadLine()) - 1; // add numeric input validation
        }

        // <code for getting actual price>
    }
}