using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lasstName = Console.ReadLine();

        Console.WriteLine($"\nYour name is {firstName}, {firstName} {lasstName}.");
    }
}