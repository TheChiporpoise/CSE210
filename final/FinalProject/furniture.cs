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

    public override void OnScan()
    {
        throw new NotImplementedException();
    }

    public void PromptTeamCarry()
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