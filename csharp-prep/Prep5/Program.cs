using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int square = SquareNumber(num);
        DisplayResult(name,square);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What's your name? ");
        string name = Console.ReadLine();

        return name;
    }
    
    static int PromptUserNumber()
    {
        Console.Write("What's your favorite number? ");
        int num = Convert.ToInt16(Console.ReadLine());

        return num;
    }

    static int SquareNumber(int num)
    {
        int square = num * num;

        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}