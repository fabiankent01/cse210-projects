using System;

public class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public override void RecordEvent()
    {
        IsComplete();
        Console.WriteLine($"Congratulations! You have earned {GetPoints()} points !");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal Goal:|{GetName()}|{GetDescription()}|{GetPoints()}|{IsComplete()}\n";    
    }

}