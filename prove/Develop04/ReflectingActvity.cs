using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity(string name, string description) : base(name, description, 0)
    {
        Console.Clear();
    }

        public void StorePrompt()
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomNumber = random.Next(_prompts.Count);
        return _prompts[randomNumber];
    }

    public void StoreRandomQuestion()
    {
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int randomNumber = random.Next(_questions.Count);
        string randomQuestion = _questions[randomNumber];
      
       _questions.RemoveAt(randomNumber);
        return randomQuestion;
    }

    public void Run()
    {
        Console.Write("\nHow long, in seconds, would you like for your sessions: ");
        string durationInput = Console.ReadLine();
        int duration = int.Parse(durationInput);
        _duration = duration;

        Console.Clear();

        Console.WriteLine("Get Ready...");
        ShowSpinner(5);

        Console.WriteLine("\nConsider the following prompt:");
        string newPrompt = GetRandomPrompt();
        Console.WriteLine($"\n---- {newPrompt} ----");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue:");
        Console.ReadLine();
        Console.Write("Now ponder on each of the following questions and how they relate to this experience.");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(6);
        Console.Clear();

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(duration);

        do
        {
            DateTime CurrentTime = DateTime.Now;
            if (CurrentTime < end)
            {
                //This code will run as far as the there are questions in the list
                if (_questions.Count > 0)
                {
                    string newQuestion = GetRandomQuestion();
                    Console.Write($"> {newQuestion}");
                    ShowSpinner(10);
                    Thread.Sleep(500);
                    Console.WriteLine();
                }
                else
                {
                    ShowDotCountDown();
                    Console.WriteLine("\nNo more prompts available. Session complete!");
                    break; // Exit the loop when all prompts are displayed
                }
            }
        } while (DateTime.Now < end);
    }
}