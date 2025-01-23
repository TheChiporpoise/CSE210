using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        List<int> nums = new List<int>();
        int num = -1;

        while (num != 0)
        {
            num = UserInput();
            if (num != 0)
            {
                nums.Add(num);
            }
        }

        int tot = Total(nums);
        Console.WriteLine($"The sum is: {tot}");

        float avg = Average(nums, tot);
        Console.WriteLine($"The average is: {avg}");

        int max = Max(nums);
        Console.WriteLine($"The max is: {max}");

        string sorted = ListToString(SortNums(nums));
        Console.WriteLine($"{sorted}");

    }

    static int UserInput()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt16(Console.ReadLine());
        
        return num;
    }

    static int Total(List<int> nums)
    {
        int tot = 0;
        for (int i = 0; i < nums.Count(); i++)
        {
            tot += nums[i];
        }

        return tot;
    }

    static float Average(List<int> nums, int tot)
    {
        float avg = tot / nums.Count();
        return avg;
    }

    static int Max(List<int> nums)
    {
        int high = 0;

        for (int i = 0; i < nums.Count(); i++)
        {
            if (high < nums[i])
            {
                high = nums[i];
            }
        }

        return high;
    }

    static List<int> SortNums(List<int> nums)
    {
        List<int> tempList = nums;

        for (int i = 0; i < nums.Count(); i++)
        {
            for (int j = 0; j < nums.Count() - 1; j++)
            {
                int num = tempList[j];
                if (nums[j + 1] < nums[j])
                {
                    tempList.Remove(num);
                    tempList.Add(num);
                }
            }
        }
        return tempList;
    }

    static string ListToString(List<int> nums)
    {
        string stringList = "";
        for (int i = 0; i < nums.Count; i++)
        {
            stringList += nums[i] + ((i != nums.Count - 1) ? ", " : "");
        }

        return stringList;
    }
}