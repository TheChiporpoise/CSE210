public class Breathe : Activity
{
    static String _breatheDesc = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    public Breathe() : base()
    {
    }

    public Breathe(String name) : base(name, _breatheDesc)
    {
    }

    public void DoActivity()
    {
        double trueDuration = Convert.ToDouble(_duration) / 10;
        trueDuration = 10 * Math.Ceiling(trueDuration);

        System.Console.WriteLine("Get ready...");
        ShowAnimation(5000);

        for (int time = 0; time < _duration * 1000; time += 10000)
        {
            System.Console.Write("Breathe in...5");
            Thread.Sleep(1000);
            System.Console.Write("\b4");
            Thread.Sleep(1000);
            System.Console.Write("\b3");
            Thread.Sleep(1000);
            System.Console.Write("\b2");
            Thread.Sleep(1000);
            System.Console.Write("\b1");
            Thread.Sleep(1000);
            System.Console.Write("\b \n");
            
            System.Console.Write("Breathe out...5");
            Thread.Sleep(1000);
            System.Console.Write("\b4");
            Thread.Sleep(1000);
            System.Console.Write("\b3");
            Thread.Sleep(1000);
            System.Console.Write("\b2");
            Thread.Sleep(1000);
            System.Console.Write("\b1");
            Thread.Sleep(1000);
            System.Console.Write("\b \n");

            System.Console.WriteLine();
        }
        
        System.Console.WriteLine($"Well done!\n\nYou have completed {trueDuration} seconds of the {_name} Activity.");
        ShowAnimation(5000);
    }
}