using System;
using System.Collections.Generic;

public class ListingActivity : Activity 
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity(string name, string description) : base(name, description, 0)
    {
        Console.Clear();
    }

    public void StorePrompt()
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Hole Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomNumber = random.Next(_prompts.Count);
        return _prompts[randomNumber];
    }

    // public List<string> GetListFromUser()
    // {
    //     List<string> UserEntry = new List<string>();
    // }
    public void Run()
    {
        Console.Write("\nHow long, in seconds, would you like for your sessions: ");
        string durationInput = Console.ReadLine();
        int duration = int.Parse(durationInput);
        _duration = duration;

        Console.Clear();

        Console.WriteLine("Get Ready...");
        ShowSpinner(5);

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        string newPrompt = GetRandomPrompt();
        Console.WriteLine($"---- {newPrompt} ----");
        ShowDotCountDown();
        Console.Write("\nYou may begin in: ");
        ShowCountDown(6);
        Console.WriteLine();

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(duration);

        _count = 0;
        do
        {
            DateTime CurrentTime = DateTime.Now;
            if (CurrentTime < end)
            {
                Console.Write(">");
                Console.ReadLine();
                _count++;
            }
        } while (DateTime.Now < end);
        ShowDotCountDown();
        Console.WriteLine($"\nYou listed {_count} items");
    }
}