using System;
using System.Diagnostics.Contracts;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Jakob","Programming with Classes");
        assignment1.GetSummary();
        
        MathAssignment assignment2 = new MathAssignment("Joshua","Training","Section 6.8","Problems 1-7 odd");
        assignment2.GetSummary();
        assignment2.GetHomeworkList();

        WritingAssignment assignment3 = new WritingAssignment("Andrew","Essay","The Rise of Crypto");
        assignment3.GetSummary();
        assignment3.GetWritingInformation();
    }
}