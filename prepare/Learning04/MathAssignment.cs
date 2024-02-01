using System;

public class MathAssignment : Assignment
{
    private string _textBookSection;
    private string _problems;

    public MathAssignment() : base()
    {
        SetStudentName("Moses");
    }

    public MathAssignment(string name, string topic, string textBook, string problem) : base(name, topic)
    {
        _textBookSection = textBook;
        _problems = problem;
    }

    public string GetSection()
    {
        return _textBookSection;
    }

    public void SetSection(string textBook)
    {
        _textBookSection = textBook;
    }

        public string GetProblem()
    {
        return _problems;
    }

    public void SetProblems(string problem)
    {
        _problems= problem;
    }

    public string GetHomeWorkList()
    {
        return $"{_textBookSection} - {_problems}";
    }
}