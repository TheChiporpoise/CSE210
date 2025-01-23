using System;

class Program
{
    static void Main(string[] args)
    {
        int magic = RandomNumber();
        int guess = -1;

        while (magic != guess)
        {
            guess = UserGuess();
            HighOrLow(magic, guess);
        }
        Console.WriteLine($"You Got it! {magic} was the magic number!");
    }

    static int RandomNumber()
    {
        Random randomGenerator = new Random();
        int num = randomGenerator.Next(1, 100);

        return num;
    }

    static int UserGuess()
    {
        Console.Write("What is your guess? ");
        string guess = Console.ReadLine();

        return Convert.ToInt16(guess);
    }

    static void HighOrLow(int magic, int guess)
    {
        if (magic < guess)
        {
            Console.WriteLine("Lower");
        }
        else if (magic > guess)
        {
            Console.WriteLine("Higher");
        }
    }
}