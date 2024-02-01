using System;
using System.Collections.Generic;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity()
    {
        _name = " ";
        _description = " ";
    }

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;   
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\n{_description}");
        // SetDuration(); 
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!! \n\nYou have completed another {_duration} seconds of the {_name}.");
    }

    public void ShowSpinner(int seconds)
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
        DateTime end = start.AddSeconds(seconds);
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

    public void ShowCountDown(int seconds)
    {
        for (int i=seconds; i>0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void ShowDotCountDown()
    {
        for (int i=5; i>0; i--)
        {
            Console.Write(".");
            Thread.Sleep(500);
            
        }
    }
}