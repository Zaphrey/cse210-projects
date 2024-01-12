using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string valueFromUser = Console.ReadLine();

        int gradePercentage = int.Parse(valueFromUser);
        string gradeLetter;

        if (gradePercentage >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradePercentage >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercentage >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercentage >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        // Stretch Challenge:
        int remainder = gradePercentage % 10;
        string sign = "";

        // Add signs to grade letter if able:
        // Check if grade percentage is greater than an "F",
        // otherwise, ignore applying the sign to the letter.
        if (gradePercentage >= 60)
        {
            // Check if remainder is greater than 7, and set the sign
            // to "+" only if gradeLetter is not equal to "A"
            if (remainder >= 7 && gradeLetter != "A")
            {
                sign = "+";
            }
            else if (remainder < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is: {gradeLetter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You've passed the class!");
        }
        else
        {
            Console.WriteLine("Better luck next time :(");
        }
    }
}