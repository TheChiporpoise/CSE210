public class SimpleGoal : Goal
{
    // One time goal
    private Boolean _completed = false;

    public SimpleGoal() : base()
    {
        
    }
    public SimpleGoal(String name, String description, int points) : base(name, description, points)
    {

    }
    public SimpleGoal(String rep) : base(rep)
    {
        String[] goalRaw = rep.Split("`");
        _completed = Convert.ToBoolean(goalRaw[5]);
    }
    public override String GetRep()
    {
        return $"1`{_name}`{_description}`{_points}`{_awardedPoints}`{_completed}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void AwardPoints()
    {
        if (_completed)
        {
            return;
        }
        else
        {
            _completed = true;
            _name += " ✓";
            base.AwardPoints();
        }
    }
}