using System;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using Microsoft.VisualBasic;

class Program
{
    static Journal currentJournal;
    static String currentFilePath;

    static void Main(string[] args)
    {
        System.Console.WriteLine();
        String userIn = "0";
        String pause = "";
        while (userIn != "6")
        {
            System.Console.Write
            (
                "[1]: Create a New Journal?\n" +
                "[2]: Load a Journal?\n" +
                "[3]: Add an Entry to current Journal?\n" +
                "[4]: Save current changes?\n" +
                "[5]: Display current Journal's Entries?\n" +
                "[6]: Quit\n" +
                "What would you like to do? "
            );
            userIn = System.Console.ReadLine();
            
            if (userIn == "1")
            {  
                New();
            }
            else if (userIn == "2")
            {
                Load();
            }
            else if (userIn == "3")
            {
                AddEntry();
            }
            else if (userIn == "4")
            {
                Save();
            }
            else if (userIn == "5")
            {
                if (currentJournal == null)
                {
                    System.Console.WriteLine("Please Load a journal first.");
                }
                else{
                    currentJournal.Display();
                    System.Console.Write("[Press enter to continue]");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "6")
            {
                if (currentJournal.changed) {
                    System.Console.Write("Would you like to save first? [Y/N] ");
                    if (System.Console.ReadLine() == "Y" || System.Console.ReadLine() == "y")
                    {
                        Save();
                    }
                }
                return;
            }
            userIn = "0";
        }
    }

    static Journal New()
    {
        Journal newJ = new Journal();

        System.Console.Write("What would you like to name this Journal? ");
        String journalName = System.Console.ReadLine();
        System.Console.WriteLine("Paste the file path you would like to save this Journal in:");
        String folderPath = System.Console.ReadLine();

        if (File.Exists($"{folderPath}\\{journalName}.txt"))
        {
            System.Console.Write("File exists, would you like to load instead? [Y/N] ");
            if (System.Console.ReadLine() == "Y" || System.Console.ReadLine() == "y")
            {
                Load();
            }
            else
            {
                return newJ; // needed to return a journal to escape function
            }
        }
        File.WriteAllLines($"{folderPath}\\{journalName}.txt",[]);
        
        currentJournal = newJ;
        currentFilePath = $"{folderPath}\\{journalName}.txt";
        
        return newJ;
    }

    static void Load()
    {
        System.Console.Write("Enter file path: ");
        currentFilePath = System.Console.ReadLine();
        currentJournal = new Journal();
        
        Array raw = File.ReadAllLines(currentFilePath);
        List<String> semi = [];
        foreach (String line in raw)
        {
            semi.Add(line);
        }
        
        for (int i = 1; i <= semi.Count();)
        {
            Entry ent = new Entry();
            ent.date = semi[i];
            ent.prompt = semi[i + 1];
            ent.text = semi[i + 2];

            currentJournal.entries.Add(ent);
            i += 5;
        }
    }

    static void Save()
    {
        if (currentFilePath == null || currentJournal == null )
        {
            System.Console.WriteLine("Please Load a journal first.");
            return;
        }

        System.Console.WriteLine("Saving...");

        List<String> formattedJournal = [];
        int entNum = 1;
        foreach (Entry ent in currentJournal.entries)
        {
            formattedJournal.Add($"Entry #{entNum++}");
            formattedJournal.Add(ent.date);
            formattedJournal.Add(ent.prompt);
            formattedJournal.Add(ent.text);
            formattedJournal.Add("");
        }
        File.WriteAllLines(currentFilePath, formattedJournal);
        System.Console.WriteLine("Journal saved!");
    }

    static void AddEntry()
    {
        Entry newEnt = new Entry();

        DateTime dateTime = DateTime.Now; 

        String prompt = RandomPrompt();

        newEnt.date = $"{dateTime}";
        newEnt.prompt = $"{prompt}";
        System.Console.WriteLine($"{prompt}");
        newEnt.text = System.Console.ReadLine();

        currentJournal.entries.Add(newEnt);
    }

    static String RandomPrompt()
    {
        Random rand = new Random();

        List<String> prompts = 
        [
            "Who did you talk to today?",
            "What did you get done today?",
            "What plans did you make today?",
            "What did you learn toady?",
            "What are you looking forward to?",
            "What was something funny that happened today?",
            "What did you do for fun today?",
            "What did you study in the scriptures?",
            "Where did you go today?",
            "Write a haiku!"
        ];
        
        return prompts[rand.Next(prompts.Count())];
    }
}