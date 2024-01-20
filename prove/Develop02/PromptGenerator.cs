using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

//default prompts being added to the list
    public void StorePrompt()
    {
        _prompts.Add("What's an interesting thing you did today? ");
        _prompts.Add("What was the best part of your day?");
        _prompts.Add("Who was the most interesting person you interacted with today?");
        _prompts.Add("What is one thing you do not regret doing today?");
    }

//code for others to be able to add their own prompts
    public void AddPrompt(string prompts)
    {
        _prompts.Add(prompts);
        Console.WriteLine("Your prompts has been added to the prompt list.");
    }

    //getting a random prompt
    public string GetRandomPrompt()
    {
        //call the random function
        Random random = new Random();
        //generate a random number
        int number = random.Next(_prompts.Count);
        //use random number as index for the prompt
        return _prompts[number];
    }

    public void printPrompt()
    {
        //print out all the prompt in the class list(not really needed)
        foreach (string prompt in _prompts)
        {
            Console.WriteLine(prompt);
        }
    }
}