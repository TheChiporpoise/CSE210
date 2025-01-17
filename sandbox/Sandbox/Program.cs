using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int num = GetNumber();

        List<int> factors = PrimFact(num);
        string facts = ToFacts(factors);

        Console.WriteLine(OutMessage(num, facts, factors));
    }

    static int GetNumber() {
        int num;
        while (true)
        {
            Console.Write("Give me a positive whole number: ");
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Try again.");
                continue;
            }
            break;
        }

        return num;
    }

    static List<int> PrimFact(int num)
    {
        List<int> factors = [];
        int n = num;

        while ((n & 1) == 0)
        {
            factors.Add(2);
            n /= 2;
            // Console.Write($"{n}, ");
        }

        for (var f = 3; f*f <= n; f += 2)
        {
            // Console.WriteLine("Made it to odd");
            while ((n % f) == 0) {
                // Console.WriteLine("Made it to while");
                factors.Add(f);
                n /= f;
            }
        }

        if (num != 1)
        {
            factors.Add(n);
        }

        return factors;
    }

    static string ToFacts(List<int> factors)
    {
        string facts = "";
        for (int i = 0; i < factors.Count; i++)
        {
            facts += factors[i] + ((i != factors.Count - 1) ? ", " : "");
        }

        return facts;
    }

    static string OutMessage(int num, string facts, List<int> factors)
    {
        string message;
        if (factors.Count() == 1)
        {
            message = $"\n{num} is prime";
        }
        else
        {
            message = $"\nThe factors of {num} are {facts}";
        }

        return message;
    }
}