class WritingAssignment : Assignment
{
    String _title;

    public WritingAssignment() : base()
    {
        _title = "N/A";
    }

    public WritingAssignment(String name, String topic, String title) : base(name, topic)
    {
        _title = title;
    }

    public void GetWritingInformation()
    {
        System.Console.WriteLine($"{_title} by {_studentName}");
    }
}