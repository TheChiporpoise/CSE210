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
                currentJournal.AddEntry();
            }
            else if (userIn == "4")
            {
                currentJournal.Save(currentFilePath);
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
                        currentJournal.Save(currentFilePath);
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
}