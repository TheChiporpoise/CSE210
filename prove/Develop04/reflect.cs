public class Reflect : Activity
{
    private List<String> _promptList = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];
    private List<String> _questionList = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    static String _reflectDesc = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    public Reflect() : base()
    {
    }
    public Reflect(String name) : base(name, _reflectDesc)
    {
    }

    public String RandomPrompt()
    {
        Random rand = new Random();
        int randIndex = rand.Next(_promptList.Count());

        String prompt = _promptList[randIndex];

        return prompt;
    }

    public String RandomQuestion()
    {
        Random rand = new Random();
        int randIndex = rand.Next(_questionList.Count());

        String question = _questionList[randIndex];
        _questionList.Remove(question);

        return question;
    }

    public void DoActivity()
    {
        double trueDuration = Convert.ToDouble(_duration) / 10;
        trueDuration = 10 * Math.Ceiling(trueDuration);

        System.Console.WriteLine("Get ready...");
        ShowAnimation(5000);

        System.Console.WriteLine($"Consider the following prompt:\n\n--- {RandomPrompt()} ---\n\nWhen you have something in mind, press enter to continue.");
        System.Console.ReadLine();
        System.Console.Clear();

        for (int i = 0; i < trueDuration && i < 90; i += 10)
        {
            System.Console.Write($"{RandomQuestion()}  ");
            ShowAnimation(10000);
        }

        if (90 < trueDuration)
        {
            ShowAnimation(1000 * (Convert.ToInt32(trueDuration) % 90)); // only 9 questions, prevents selecting from empty list
        }
        _questionList = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ]; // resets list for next run

        System.Console.WriteLine($"Well done!\n\nYou have completed {trueDuration} seconds of the {_name} Activity.");
        ShowAnimation(5000);
    }
}