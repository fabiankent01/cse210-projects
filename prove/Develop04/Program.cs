using System;

class Program
{
    static void Main(string[] args)
    {
        int input = -1;
        while (!(input == 4))
        {
            Console.Clear();
            Console.WriteLine($"Menu Options:");
            Console.Write("1. Start Breathing Activity  \n2. Start Reflecting Activity\n3. Start Listing Activity\n4. Quit\nSelect a choice from the menu: ");
            string userInput = Console.ReadLine();
            int choice = int.Parse(userInput);

            if (choice == 1)
            {
                string breatheName = "Breathing Activity";
                string breatheDesc = "This activity will help you relax by walking your through "+
                                                        "breathing in and out slowly. Clear your mind and focus on your breathing."; 
                BreathingActivity breathe = new BreathingActivity(breatheName, breatheDesc);
                breathe.DisplayStartingMessage();
                breathe.Run();
                breathe.DisplayEndingMessage();
                breathe.ShowSpinner(5);
                // breathe.SetDuration(int.Parse(duration))
            }

            else if (choice == 2)
            {
                string reflectName = "Reflecting Activity";
                string reflectDesc = "This activity will help you reflect on times in your life when you have shown strength and resilience. "+
                                                    "This will help you recognize the power you have and how you can use it in other aspects of your life.";
                ReflectingActivity reflect = new ReflectingActivity(reflectName, reflectDesc);
                reflect.StorePrompt();
                reflect.StoreRandomQuestion();
                reflect.DisplayStartingMessage();
                reflect.Run();
                reflect.DisplayEndingMessage();
                reflect.ShowSpinner(5);
            }

            else if (choice == 3)
            {
                string ListName = "Listing Activity";
                string ListDesc = "This activity will help you reflect on the good things in your life by having"+
                                                " you list as many things as you can in a certain area.";
                ListingActivity Listing = new ListingActivity(ListName, ListDesc);
                Listing.StorePrompt();
                Listing.DisplayStartingMessage();
                Listing.Run();
                Listing.DisplayEndingMessage();
                Listing.ShowSpinner(5);
            }
            
            else if (choice == 4)
            {
                break;
            }
        }
    }
}