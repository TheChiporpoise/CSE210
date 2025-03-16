using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

class Program
{
    static List<Goal> goalList = new List<Goal>();
    static String currentFilePath = "NONE";

    static void Main(string[] args)
    {
        System.Console.WriteLine();
        String userIn = "0";

        while (userIn != "6")
        {
            System.Console.Clear();
            System.Console.Write
            (
                "[1]: Add a New Goal?\n" +
                "[2]: Load a List of Goals?\n" +
                "[3]: Save Goals?\n" +
                "[4]: Select a Goal?\n" +
                "[5]: Get total points?\n" +
                "[6]: Quit\n" +
                "What would you like to do? "
            );
            userIn = System.Console.ReadLine();
            
            if (userIn == "1")
            {  
                System.Console.Clear();
                System.Console.Write
                (
                    "[1]: Simple Goal\n" +
                    "[2]: Eternal Goal\n" +
                    "[3]: Checklist Goal\n" +
                    "[ENTER]: Exit\n" +
                    "What type of goal? "
                );
                userIn = System.Console.ReadLine();
                System.Console.Clear();

                if (userIn == "1")
                {
                    goalList.Add(PromptSimpleGoal());
                }
                else if (userIn == "2")
                {
                    goalList.Add(PromptEternalGoal());
                }
                else if (userIn == "3")
                {
                    goalList.Add(PromptCheckGoal());
                }
                else
                {
                    continue;
                }
            }
            else if (userIn == "2")
            {
                Load();
            }
            else if (userIn == "3")
            {
                Save();
            }
            else if (userIn == "4")
            {
                Goal currentGoal;
                System.Console.Clear();

                if (goalList.Count() == 0)
                {
                    System.Console.WriteLine("No goals in list, load a list or add goals first.");
                    System.Console.Write("Press enter to continue. ");
                    System.Console.ReadLine();

                    continue;
                }

                for (int i = 0; i < goalList.Count(); i++)
                {
                    System.Console.WriteLine($"[{i + 1}]: {goalList[i].GetName()}");
                }
                while (true)
                {
                    int cursorTop = Console.CursorTop;
                    System.Console.Write("Choose a goal from above or press ENTER to exit: ");
                    userIn = System.Console.ReadLine();
                    try
                    {
                        currentGoal = goalList[Convert.ToInt32(userIn) - 1];
                        break;
                    }
                    catch
                    {
                        Console.SetCursorPosition(0, cursorTop); 
                        Console.Write(new string(' ', Console.WindowWidth)); // To overwrites the "Choose a goal to display: " and user input
                        Console.SetCursorPosition(0, cursorTop); // So the write on the next loop is in the correct spot
                        continue;
                    }
                }

                while (true)
                {
                    System.Console.Clear();
                    System.Console.Write
                    (
                        "[1]: Display Goal\n" +
                        "[2]: Complete Goal\n" +
                        "[ENTER]: Exit\n" +
                        "What would you like to do? "
                    );
                    userIn = System.Console.ReadLine();
                    System.Console.Clear();
                    
                    if (userIn == "1")
                    {
                        currentGoal.Display();
                    }
                    else if (userIn == "2")
                    {
                        currentGoal.AwardPoints();
                    }
                    else
                    {
                        break;
                    }
                    System.Console.Write("\nPress enter when finished. ");
                    System.Console.ReadLine();
                }
                continue;
            }
            else if (userIn == "5")
            {
                int points = 0;
                foreach (Goal g in goalList)
                {
                    points += g.GetAwardedPoints();
                }
                System.Console.Clear();
                System.Console.Write($"You've got {points} so far! Press ENTER to continue. ");
                System.Console.ReadLine();
            }
            else if (userIn == "6")
            {
                System.Console.Write("Would you like to save first? [Y/N] ");
                if (System.Console.ReadLine() == "Y" || System.Console.ReadLine() == "y")
                {
                    Save();
                }
                return;
            }
            userIn = "0";
        }
    }

    static void Load()
    {
        while (true) {
            System.Console.Write("Paste full file path or press ENTER if selected by mistake: ");
            currentFilePath = System.Console.ReadLine();
            
            if (File.Exists(currentFilePath))
            {
                break;
            }
            else
            {
                System.Console.Write("Filepath doesn't lead to a valid file, Exit? [Y/N]");
                String exit = System.Console.ReadLine();
                if (exit.ToUpper() == "y")
                {
                    return; // in the case the user wishes to cancel their selection
                }
            }
        }
        System.Console.Clear();
        
        Array raw = File.ReadAllLines(currentFilePath);
        List<String> semi = [];
        foreach (String line in raw)
        {
            semi.Add(line);
        }
        
        goalList = new List<Goal>(); // resets goalList to avoid combining lists
        int corrupt = 0;
        for (int i = 0; i < semi.Count(); i++)
        {
            if (semi[i][0] == '1')
            {
                try
                {
                    SimpleGoal simple = new SimpleGoal(semi[i]);
                    goalList.Add(simple);
                }
                catch
                {
                    System.Console.WriteLine($"{i} Simple failed at index {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '2')
            {
                try
                {
                    EternalGoal eternal = new EternalGoal(semi[i]);
                    goalList.Add(eternal);
                }
                catch
                {
                    System.Console.WriteLine($"{i} Eternal failed at index {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '3')
            {
                try
                {
                    ChecklistGoal checklist = new ChecklistGoal(semi[i]);
                    goalList.Add(checklist);
                }
                catch
                {
                    System.Console.WriteLine($"Checklist failed at index {i}");
                    corrupt++;
                }
            }
            else
            {
                corrupt++;
            }
        }
        if (0 < corrupt) {
            System.Console.Write($"{corrupt} goals could not be loaded properly. Press ENTER to continue.");
        }
        else 
        {
            System.Console.Write("Loaded! Press ENTER to continue. ");
        }
        System.Console.ReadLine();
    }

    static void Save()
    {
        if (currentFilePath == "NONE")
        {
            System.Console.Write("Name your Goal List: ");
            String title = System.Console.ReadLine();
            File.Create(Path.GetFullPath($"lists\\{title}.txt").Replace("bin\\Debug\\net8.0","")); // for some reason it doesn't like to just do relative paths, removing the "bin\Debug\net8.0" fixes this
        }
        else
        {
            List<String> goalStrings = [];
            foreach (Goal g in goalList)
            {
                goalStrings.Add(g.GetRep());
            }
            File.WriteAllLines(currentFilePath, goalStrings);
        }
        System.Console.Write("Saved! Press ENTER to continue. ");
        System.Console.ReadLine();
    }

    static SimpleGoal PromptSimpleGoal()
    {
        System.Console.Write("What name would you like to give the Goal? ");
        String name = System.Console.ReadLine();
        System.Console.Write("Give a brief description of the Goal: ");
        String description = System.Console.ReadLine();
        System.Console.Write("What is the number of points to be awarded on completion? ");
        int points = Convert.ToInt32(System.Console.ReadLine());

        return new SimpleGoal(name, description, points);
    }
    static EternalGoal PromptEternalGoal()
    {
        System.Console.Write("What name would you like to give the Goal? ");
        String name = System.Console.ReadLine();
        System.Console.Write("Give a brief description of the Goal: ");
        String description = System.Console.ReadLine();
        System.Console.Write("What is the number of points to be awarded on completion? ");
        int points = Convert.ToInt32(System.Console.ReadLine());

        return new EternalGoal(name, description, points);
    }
    static ChecklistGoal PromptCheckGoal()
    {
        System.Console.Write("What name would you like to give the Goal? ");
        String name = System.Console.ReadLine();
        System.Console.Write("Give a brief description of the Goal: ");
        String description = System.Console.ReadLine();
        System.Console.Write("What is the number of points to be awarded on partial completion? ");
        int points = Convert.ToInt32(System.Console.ReadLine());
        System.Console.Write("What is the number of points to be awarded on full completion? ");
        int bonusPoints = Convert.ToInt32(System.Console.ReadLine());
        System.Console.Write("What is the total amount of times this goal must be completed? ");
        int totalToComplete = Convert.ToInt32(System.Console.ReadLine());
        System.Console.Write("Is this goal repeatable? [T/F] ");
        String repeatRaw = System.Console.ReadLine();
        Boolean canRepeat;
        if (repeatRaw.ToLower() == "t")
        {
            canRepeat = true;
        }
        else
        {
            canRepeat = false;
        }

        return new ChecklistGoal(name, description, points, totalToComplete, bonusPoints, canRepeat);
    }
}