public abstract class Goal
{
    protected String _name;
    protected String _description;
    protected int _points; // base points awarded (bonus points are subclass specific)
    protected int _awardedPoints = 0; // keeps track of how many points that goal has awarded

    public Goal()
    {
        _name = "N/A";
        _description = "N/A";
        _points = -1;
    }
    public Goal(String name, String description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public Goal(String rep)
    {
        String[] goalRaw = rep.Split("`");
        _name = goalRaw[1]; // skips index 0, as that denotes which type the goal is
        _description = goalRaw[2];
        _points = Convert.ToInt32(goalRaw[3]);
        _awardedPoints = Convert.ToInt32(goalRaw[4]);
    }
    public abstract String GetRep();
    
    public String GetName()
    {
        return _name;
    }
    public virtual void Display()
    {
        System.Console.WriteLine($"Name: {_name}\nDescription: {_description}");
    }
    public virtual void AwardPoints()
    {
        _awardedPoints += _points;
        System.Console.WriteLine($"You got {_points} points!!!");
    }
    public int GetAwardedPoints()
    {
        return _awardedPoints;
    }
}