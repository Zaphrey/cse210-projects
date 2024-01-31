using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment()
    {
        _studentName = "Anonymous";
        _topic = "Unknown";
    }

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public void SetStudentName(string name)
    {
        _studentName = name;
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public void SetTopic(string topic)
    {
        _topic = topic;
    }

    public string GetTopic()
    {
        return _topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}