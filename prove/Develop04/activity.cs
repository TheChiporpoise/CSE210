public class Activity
{
    protected String _name;
    protected String _description;
    protected int _duration; // in seconds

    public Activity()
    {
        _name = "N/A";
        _duration = -1;
    }

    public Activity(String name, String description)
    {
        _name = name;
        _description = description;
        _duration = PromptDuration();
    }

    private int PromptDuration()
    {
        DisplayIntro();

        System.Console.Write("How long, in seconds, would you like for your session? ");
        int duration = Convert.ToInt32(System.Console.ReadLine());
        
        return duration;
    }

    public void DisplayIntro()
    {
        System.Console.Clear();
        System.Console.WriteLine($"Welcome to the {_name} activity.");
        System.Console.WriteLine($"{_description}\n");
    }

    public void ShowAnimation(int duration)
    {
        for (int time = 0; time < duration; time += 1000)
        {
            System.Console.Write("\b\\");
                Thread.Sleep(250);
                System.Console.Write("\b|");
                Thread.Sleep(250);
                System.Console.Write("\b/");
                Thread.Sleep(250);
                System.Console.Write("\b-");
                Thread.Sleep(250);
        }
        System.Console.Write("\b \n");
    }

    public void DisplayWellDone()
    {
        
    }
}