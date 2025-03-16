public class ChecklistGoal : Goal
{
    private int _completedCount = 0;
    private int _totalToComplete;
    // points for each partial completion are under Goal._points
    private int _finishedPoints = 0; // bonus points
    private Boolean _canRepeat = false;
    
    public ChecklistGoal() : base()
    {
        _totalToComplete = -1;
        _finishedPoints = 0;
        _canRepeat = false;
    }
    public ChecklistGoal(String name, String description, int points, int total, int finishedPoints, Boolean canRepeat) : base(name, description, points)
    {
        _totalToComplete = total;
        _finishedPoints = finishedPoints;
        _canRepeat = canRepeat;
    }
    public ChecklistGoal(String rep) : base(rep)
    {
        String[] goalRaw = rep.Split("`");
        _totalToComplete = Convert.ToInt32(goalRaw[6]);
        _finishedPoints = Convert.ToInt32(goalRaw[7]);
        _canRepeat = Convert.ToBoolean(goalRaw[8]);
    }
    public override String GetRep()
    {
        return $"3`{_name}`{_description}`{_points}`{_awardedPoints}`{_completedCount}`{_totalToComplete}`{_finishedPoints}`{_canRepeat}"; // ` seemed like the least likely character to be used in a goal description
    }

    public override void Display()
    {
        System.Console.WriteLine($"Name: {_name}\nDescription: {_description}\nTimes Completed: {_completedCount}/{_totalToComplete}");
    }
    public override void AwardPoints()
    {
        if (_canRepeat || _completedCount < _totalToComplete)
        {
            _completedCount++;
            if (_completedCount % _totalToComplete == 0)
            {
                _awardedPoints += _finishedPoints;
                System.Console.WriteLine($"You got {_finishedPoints} points!!!");
            } else {
                _awardedPoints += _points;
                System.Console.WriteLine($"You got {_points} points!!!\n{_totalToComplete - _completedCount} more to go until you get BONUS POINTS!!!");
                if (!_canRepeat)
                {
                    _name += " ✓";
                }
            }
        }
    }
}