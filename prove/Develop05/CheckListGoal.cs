using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int bonus, int target) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public int GetTarget()
    {
        return _target;
    }

    public void SetTarget(int target)
    {
        _target = target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (!IsComplete()) // or if(!_isComplete)
        {
          
            _amountCompleted++;
            Console.WriteLine($"Congratulations! You have earned {GetPoints()} points !");
            if (_amountCompleted == GetTarget())
            {
                ShowDotCountDown();
                Thread.Sleep(1000);
                // SetPoints(GetPoints() + GetBonus());
                Console.WriteLine($"\nHoooorray!!! For reaching your target you get your bonus of {GetBonus()} points - elevating your total to {GetPoints() + GetBonus()} points!");
            }
        }
        else
        {
            SetPoints(0);
            Console.WriteLine("You have completed this goal already!!!!!");
            ShowSpinner();
            Console.Clear();
        }
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }
    
    public override bool IsComplete()
    {
        return _amountCompleted == GetTarget();
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        { 
            return $"[X] {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{GetTarget()}";
        }
        else
        {
            return $"[] {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{GetTarget()}";
        }
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist Goal:|{GetName()}|{GetDescription()}|{GetPoints()}|{GetBonus()}|{GetTarget()}|{_amountCompleted}\n";    
    }
}