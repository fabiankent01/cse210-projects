using System;

public class BreathingActivity : Activity 
{
    public BreathingActivity(string name, string description) : base(name, description, 0)
    {
        Console.Clear();
    }
    public void Run()
    {
        Console.Write("\nHow long, in seconds, would you like for your sessions: ");
        string durationInput = Console.ReadLine();
        int duration = int.Parse(durationInput);
        _duration = duration;
        // Save the duration in a variab;e, Then loop through until the 
        // duration ends.
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(5);

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(5);

            Thread.Sleep(1000);

            Console.Write("\nNow breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }

    }
}