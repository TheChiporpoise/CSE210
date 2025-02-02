class Journal
{
    public List<Entry> entries = new List<Entry>();
    public Boolean changed = false;

    public void Display()
    {
        foreach (Entry ent in entries)
        {
            ent.Display();
        }
    }

    
}