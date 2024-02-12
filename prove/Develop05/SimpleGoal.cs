using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        //The logis here is - the user will only ever want to record an event if he/she has accomplished any goal, ergo, it is "true"
        if (_isComplete == false) // or if(!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");
        }
        //The logic here is that - you're implying that any input the user gives means that he completed the goal in the index of the input
    }

    public void SetComplete(bool complete)
    {
        _isComplete = complete;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"Simple Goal:|{GetName()}|{GetDescription()}|{GetPoints()}|{IsComplete()}\n";    
    }
}