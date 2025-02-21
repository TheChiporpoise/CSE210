class Assignment
{
    protected String _studentName;
    private String _topic;

    public Assignment()
    {
        _studentName = "N/A";
        _topic = "N/A";
    }

    public Assignment(String name, String topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public void GetSummary()
    {
        System.Console.WriteLine($"{_studentName} - {_topic}");
    }
}