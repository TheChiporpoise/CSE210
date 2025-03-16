public class EternalGoal : Goal
{
    // Goal that is never fully completed, but rewards points on each instance of completion
    public EternalGoal() : base()
    {
        
    }
    public EternalGoal(String name, String description, int points) : base(name, description, points)
    {

    }
    public EternalGoal(String rep) : base(rep)
    {

    }
    public override String GetRep()
    {
        return $"2`{_name}`{_description}`{_points}`{_awardedPoints}"; // ` seemed like the least likely character to be used in a goal description
    }
}