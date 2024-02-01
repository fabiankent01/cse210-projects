using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assign = new Assignment();
        assign.SetStudentName("Flourish Idahosa-Sunny");
        assign.SetTopic("Algebra");
        Console.WriteLine(assign.GetSummary());

        MathAssignment math = new MathAssignment();
        // math.SetStudentName("Roberto Rodriguez");
        math.SetTopic("Multiplication");
        math.SetSection("Section 10.3");
        math.SetProblems("Problems 8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeWorkList());

        WritingAssignment write = new WritingAssignment();
        write.SetStudentName("Mary Waters");
        write.SetTopic("European History");
        write.SetTitle("The Causes of World War II by Mary Waters");
        Console.WriteLine(write.GetWritingInformation());
    }
}