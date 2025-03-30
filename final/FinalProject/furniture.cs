class Furniture : Item
{
    private double _deliveryFee;
    private bool _teamCarry; // should customer be prompted asking if they would like help carrying item out

    public Furniture() : base()
    {
        
    }
    public Furniture(string name, float price, bool canReturn, double deliveryFee, bool teamCarry) : base(name, price, canReturn)
    {
        _deliveryFee = deliveryFee;
        _teamCarry = teamCarry;
    }

    protected override void OnScan()
    {
        throw new NotImplementedException();
    }

    private void PromptTeamCarry()
    {

    }
}