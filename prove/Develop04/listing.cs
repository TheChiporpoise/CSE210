using System.Diagnostics;
using Microsoft.VisualBasic;

public class Listing : Activity
{
    private List<String> _promptList = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];
    private List<String> _items = [];

    static String _listingDesc = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    public Listing() : base()
    {
    }
    
    public Listing(String name) : base(name, _listingDesc)
    {
    }

    public String RandomPrompt()
    {
        Random rand = new Random();
        int randIndex = rand.Next(_promptList.Count());

        String prompt = _promptList[randIndex];

        return prompt;
    }

    private int getTimerSeconds(TimeSpan timeSpan)
    {
        String timeString = Convert.ToString(timeSpan);
        int seconds = (3600 * Convert.ToInt32("" + timeString[0] + timeString[1])) + (60 * Convert.ToInt32("" + timeString[3] + timeString[4])) + Convert.ToInt32("" + timeString[6] + timeString[7]);
        return seconds;
    }

    public void DoActivity()
    {
        System.Console.WriteLine("Get ready...");
        ShowAnimation(5000);
        
        System.Console.WriteLine($"Consider the following prompt:\n\n--- {RandomPrompt()} ---\n");
        System.Console.Write("You may begin in: .");
        for (int s = 3; s > 0; s--)
        {
            System.Console.Write($"\b{s}");
            Thread.Sleep(1000);
        }
        Stopwatch timer = new Stopwatch(); // used to compare start time to end time
        timer.Start();
        System.Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\bList away!         \n");

        while (_duration > getTimerSeconds(timer.Elapsed))
        {
            System.Console.ReadLine();
        }

        timer.Stop();

        System.Console.WriteLine($"Well done!\n\nYou have completed {_duration} seconds of the {_name} Activity.");
        ShowAnimation(5000);
    }
}