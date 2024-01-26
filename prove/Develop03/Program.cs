using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine($"Please Your preference from the list of scriptures below:");
        Console.Write("1. Genesis 1:3-6  \n2. Proverbs 3:3\nEnter your choice here: ");
        string input = Console.ReadLine();
        int choice = int.Parse(input);

        if (choice == 1)
        {
            Reference f1 = new Reference("Genesis", 1, 3, 6);
            string scriptureText = ("In the beginning God created the heaven and the earth. And the earth was"+
             "without form, and void; and darkness was upon the face of the deep. And the Spirit of God moved upon"+
              "the face of the waters. And God said, Let there be light: and there was light.");

            Scripture scripture = new Scripture(f1, scriptureText);
            // Console.WriteLine( scripture.GetDisplayText());

            string response;
            do
            {
                Console.WriteLine(scripture.GetDisplayText());
                Console.Write("\nPress 'ENTER' to hide words or type 'QUIT' to quit: ");
                response = Console.ReadLine();

                if (!(scripture.IsCompletelyHidden()))
                {
                    scripture.HideRandomWords(2);
                    Console.WriteLine("\n" + scripture.GetDisplayText());
                    Console.Clear();
                }
                else if (scripture.IsCompletelyHidden())
                {
                    break;
                }
            } while (!(response == "quit" || response == "QUIT"));
        }

        else if (choice == 2)
        {
            Reference f2 = new Reference("Proverbs", 3, 3);
            string scriptureText = ("Let not mercy and truth forsake thee: bind them about thy neck; write them upon the table of thine heart:");

            Scripture scripture = new Scripture(f2, scriptureText);
            // Console.WriteLine( scripture.GetDisplayText());

            string response;
            do
            {
                Console.WriteLine(scripture.GetDisplayText());
                Console.Write("\nPress 'ENTER' to hide words or type 'QUIT' to quit: ");
                response = Console.ReadLine();

                if (!(scripture.IsCompletelyHidden()))
                {
                    scripture.HideRandomWords(2); 
                    Console.WriteLine("\n" + scripture.GetDisplayText());
                    Console.Clear();
                }
                else if (scripture.IsCompletelyHidden())
                {
                    break;
                }
            } while (!(response == "quit"  || response == "QUIT"));
        }

        else{
            Console.WriteLine("Please restart and choose one of the options.");
        }
    }
}
        
