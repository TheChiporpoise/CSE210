class Journal
{
    public List<Entry> entries = new List<Entry>();
    public Boolean changed = false;

    public void Display()
    {
        System.Console.WriteLine();
        foreach (Entry ent in entries)
        {
            ent.Display();
        }
    }

    public void Save(string currentFilePath)
    {
        if (currentFilePath == null)
        {
            System.Console.WriteLine("Please Load a journal first.");
            return;
        }

        System.Console.WriteLine("Saving...");

        List<String> formattedJournal = [];
        int entNum = 1;
        foreach (Entry ent in entries)
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
    
    public void AddEntry()
    {
        Entry newEnt = new Entry();

        DateTime dateTime = DateTime.Now; 

        String prompt = RandomPrompt();

        newEnt.date = $"{dateTime}";
        newEnt.prompt = $"{prompt}";
        System.Console.WriteLine($"{prompt}");
        newEnt.text = System.Console.ReadLine();

        entries.Add(newEnt);
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