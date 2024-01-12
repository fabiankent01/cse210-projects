using System;

class Program
{
    static void Main(string[] args)
    {
        // For parts 1 and 2 where the user is asked for a number
        Console.WriteLine("What is your magic number? ");
        int number = int.Parse(Console.ReadLine());

        // For part 3 where a random number is generated
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed it!");
            }
        }
    }
}