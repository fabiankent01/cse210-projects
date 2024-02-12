using System;
using System.Collections.Generic;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    protected int _points;



    public Goal()
    {}

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _shortName;
    }

    public void SetName(string name)
    {
        _shortName = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }
    public void ShowSpinner()
    {
        List<string> animatedStrings = new List<string>();
        animatedStrings.Add("|");
        animatedStrings.Add("/");
        animatedStrings.Add("_");
        animatedStrings.Add("\\");
        animatedStrings.Add("|");
        animatedStrings.Add("/");
        animatedStrings.Add("_");
        animatedStrings.Add("\\");

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(3);
        do
        {
            DateTime CurrentTime = DateTime.Now;
            foreach (string i in animatedStrings)
            {
                if (CurrentTime < end)
                {
                    Console.Write(i);
                    Thread.Sleep(500);
                    Console.Write("\b \b");
                }
            }
        } while (DateTime.Now < end);      
    }

    public void ShowDotCountDown()
    {
        for (int i=20; i>0; i--)
        {
            Console.Write(".");
            Thread.Sleep(100);
        }
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();
    
    public virtual string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[X] {_shortName} ({_description})";
        }
        else 
        {
            return $"[] {_shortName} ({_description})";
        }
    }

    public abstract string GetStringRepresentation();
}