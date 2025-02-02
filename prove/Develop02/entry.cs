class Entry 
{
    public String date;
    public String prompt;
    public String text;

    public void Display()
    {
        System.Console.WriteLine($"Date: {date}");
        System.Console.WriteLine($"Prompt: {prompt}");
        System.Console.WriteLine($"Entry: {text}\n");
    }
}