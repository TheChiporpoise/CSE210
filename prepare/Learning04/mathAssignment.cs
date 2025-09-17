class MathAssignment : Assignment
{
    private String _textbookSection;
    private String _problems;

    public MathAssignment() : base()
    {
        _textbookSection = "N/A";
        _problems = "N/A";
    }

    public MathAssignment(String name, String topic, String section, String problems) : base(name, topic)
    {
        _textbookSection = section;
        _problems = problems;
    }

    public void GetHomeworkList()
    {
        System.Console.WriteLine($"{_textbookSection} {_problems}");
    }
}