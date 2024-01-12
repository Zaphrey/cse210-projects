using System;

class Program
{
    static void Main(string[] args)
    {
        string keepPlaying = "yes";

        // Start a loop that asks the user if
        // they would like to play again.
        // Only continue if they answer "yes".
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);

            int guess = 0;
            int guessTries = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();

                guess = int.Parse(userInput);

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }

                guessTries ++;
            }

            Console.WriteLine($"You guessed it! You got it in {guessTries} tries.");

            Console.Write("Would you like to play again? [yes/no]: ");
            keepPlaying = Console.ReadLine();
        }
        while (keepPlaying == "yes");
    }
}