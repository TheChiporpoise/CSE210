using System;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {
        float grade = -1f;
        while (100.0 < grade || grade < 0.0)
        {
            Console.Write("What is your grade out of 100? ");
            grade = float.Parse(Console.ReadLine());
        }

        string letter = "";
        string pass = "passed";
        if (grade >= 90)
        {
            letter = "n A";
        }
        else if (grade >= 80)
        {
            letter = " B";
        }
        else if (grade >= 70)
        {
            letter = " C";
        }
        else if (grade >= 60)
        {
            letter = " D";
            pass = "failed";
        }
        else
        {
            letter = "n F";
            pass = "failed";
        }
        Console.WriteLine($"You got a{letter}, you {pass}!");
    }
}