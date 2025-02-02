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

    
}