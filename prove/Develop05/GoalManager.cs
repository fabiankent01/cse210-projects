using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goalList;
    private int _score;

    public GoalManager()
    {
        _goalList = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public void Start()
    {
        int end = -1;
         while (!(end == 6))
         {

            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options: \n");
            Console.Write("1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n"+
                                    "5. Record Events\n6. Quit\nSelect a choice from the menu: ");
            string userInput = Console.ReadLine();
            int choice = int.Parse(userInput);

            if (choice == 1)
            {
                Console.WriteLine("The types of Goals are:  \n  1. Simple Goals \n  2. Eternal Goals\n  3. Checklist Goals ");
                Console.Write("Which type of Goal would you like to create? ");
                string g = Console.ReadLine();
                int goal = int.Parse(g);

                if  (goal == 1)
                {
                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();

                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this Goal? ");
                    string p = Console.ReadLine();
                    int points = int.Parse(p);

                    CreateGoal(name, description, points, 0, 0);
                }

                else if (goal == 2)
                { 
                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();

                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this Goal? ");
                    string p = Console.ReadLine();
                    int points = int.Parse(p);

                    CreateGoal(name, description, points, 0, -1);          
                }
                
                else if (goal == 3)
                {
                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();

                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this Goal? ");
                    string p = Console.ReadLine();
                    int points = int.Parse(p);

                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    string t = Console.ReadLine();
                    int target = int.Parse(t);

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    string b = Console.ReadLine();
                    int bonus = int.Parse(b);

                    CreateGoal(name, description, points, bonus, target);
                }
            }

            else if (choice == 2)
            {
                ListGoalDetails();
            }

            else if (choice == 3)
            {
                Console.Write("What is the filename for the file?(Please add the file type .txt/.csv): ");
                string file = Console.ReadLine();
                SaveGoals(file);
            }

            else if (choice == 4)
            {
                Console.Write("What is the name of the file you want to Load?(Please add the file type .txt/.csv): ");
                string loadFile = Console.ReadLine();
                LoadGoals(loadFile);
            }

            else if (choice ==5)
            {
                 if (_goalList.Count() == 0)
                {
                    Console.WriteLine("You have not made any goal.");
                }
                else
                {
                    ListGoalNames();
                    RecordEvent();
                }
            }

            else if(choice == 6)
            {
                break;
            }

            else if (choice > 6)
            {
                Console.WriteLine("\nInvalid input.");
                ShowSpinner();
                Console.Clear();
            }
         }
    }
    /////////////////////////// /////////////////////////// ////////////////////////  //////////////////////////////////////
// ///////////////////////////////////////////////// ///////////////////////// /////////////////////////// ////////////
    public void ShowDotCountDown(char obj)
    {
        for (int i=10; i>0; i--)
        {
            Console.Write($"{obj}  ");
            Thread.Sleep(100);
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Ensure UTF-8 encoding for Unicode characters

        // Unicode characters for decoration
        char star = '\u2605'; // ★ (Black Star)
        char cup = '\u1F3C'; 
        char flower = '\u273F'; // ✿ (Flower)
        GetScore(); // Assuming this method sets _score to the initial score
        Console.WriteLine($"\nYou have {GetScore()} points");
        if (GetScore() == 50)
        {
            ShowDotCountDown(flower);
            Console.WriteLine($"\n{flower}  You are in the HALF-CENTURY club. KEEP IT UP");
        }
        else if (GetScore() >50 && GetScore() <100)
        {
            ShowDotCountDown(star);
            Console.WriteLine($"\n{star}  You have surpassed the HALF-CENTURY club. KEEP GOING. LET'S SEE YOU JOIN THE CENTURY CLUB");
        }
        else if (GetScore() == 100)
        {
            ShowDotCountDown(cup);
            Console.WriteLine($"\n{cup}  You've hit 100 points and entered the prestigious CENTURY club. Keep up the great work!");
        }
        else if (GetScore() >100 && GetScore() < 500)
        {
            ShowDotCountDown(cup);
            Console.WriteLine($"\n{cup}  You're now a MAESTRO in the prestigious CENTURY club. LET'S GET YOU UP TO 500 POINTS!");
        }
        else if (GetScore() ==500)
        {
            ShowDotCountDown(star);
            Console.WriteLine($"\n{star}  HAVING earned 500 points. YOU'RE NOW A VIRTUOSO!!!!!!!!");
        }
        else if (GetScore() > 500 && GetScore() < 1000)
        {
            ShowDotCountDown(cup);
            Console.WriteLine($"\n{cup}  You're a VIRTUOSO. LET'S GET YOU UP TO 1000 POINTS!");
        }
        else if (GetScore() ==1000)
        {
            ShowDotCountDown(flower);
            Console.WriteLine($"\n{flower}  ACE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
     }

    public void ListGoalNames()
    {
        Console.WriteLine("The Goals are:");
         for (int i = 0; i < _goalList.Count; i++)
        {
            Console.WriteLine($"{i+1}. "+_goalList[i].GetName());
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The Goals are:");
        for (int i = 0; i < _goalList.Count; i++)
        {
            Console.WriteLine($"{i+1}."+_goalList[i].GetDetailsString());
        }
    }
    
    public void CreateGoal(string name, string description, int points, int bonus, int target)
    {
        if (target == 0)
        {
            _goalList.Add( new SimpleGoal(name, description, points));
        }
        else if (target < 0)
        {
            _goalList.Add( new EternalGoal(name, description, points));
        }
        else if (target >= 0 && bonus >= 0)
        {
            _goalList.Add( new ChecklistGoal(name, description, points, bonus, target));
        }
    }

    public void RecordEvent()
    {
        Console.Write("Which Goal did you accomplish? ");
        string g = Console.ReadLine();
        int goal = int.Parse(g) - 1;

        if (goal >= 0 && goal < _goalList.Count())
        {
            GetScore();
            Goal goalName = _goalList[goal];
            if (!goalName.IsComplete())
            {
                if (goalName is ChecklistGoal check)
                {
                    check.RecordEvent();
                    if (check.GetAmountCompleted() == check.GetTarget())
                    {
                        _score = GetScore() + check.GetPoints() + check.GetBonus();
                    }
                    else
                    {
                        _score = GetScore() + check.GetPoints();
                    }
                    Console.WriteLine($"You now have {_score} points");
                    SetScore(_score);
                }
                else
                {
                    goalName.RecordEvent();
                    _score = GetScore() + goalName.GetPoints();
                    Console.WriteLine($"You now have {_score} points");
                    SetScore(_score);
                }
            }
            else
            {
                Console.WriteLine("You have completed this goal already!!!!!!");
                ShowSpinner();
                Console.Clear();
            }
            
        }
        else
        {
            Console.WriteLine("No such Goal.");
        }
    }

    public void SaveGoals(string file)
    {
        using (StreamWriter outPut = new StreamWriter(file))
        {
            outPut.WriteLine(GetScore());
            foreach (Goal goal in _goalList)
            {
                outPut.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string file)
    {
        _goalList.Clear();
        int score = int.Parse(File.ReadLines(file).First());
        SetScore(score);
        string[] goals = System.IO.File.ReadAllLines(file);

        for (int i = 1; i < goals.Length; i++)
        {
            // string clear = goal.Replace("Simple Goal:", "").Trim();  not needed
            string clear = goals[i];
            string[] parts = clear.Split('|');

            if (parts.Length == 5)
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]); // Parse the completion status

                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                simpleGoal.SetComplete(isComplete); // Set the completion status
                _goalList.Add(simpleGoal);
            }

            else if (parts.Length == 4)
            {
                CreateGoal(parts[1], parts[2], int.Parse(parts[3]), -1, 0);
            }
            else if (parts.Length == 7)
            {
                int amountCompleted = int.Parse(parts[6]);
                ChecklistGoal checklist = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),int.Parse(parts[4]),int.Parse(parts[5]));
                checklist.SetAmountCompleted(amountCompleted);
                _goalList.Add(checklist);
            }
        }
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
}