using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string userValue = Console.ReadLine();
            int userNumber = int.Parse(userValue);

            if (userNumber == 0)
            {
                break;
            }
            else
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        int largestNumber = 0;
        int smallestPositiveNumber = 10000;

        foreach (int number in numbers)
        {
            sum += number;

            if (number > largestNumber)
            {
                largestNumber = number;
            }

            if (number > 0 && smallestPositiveNumber > number)
            {
                smallestPositiveNumber = number;
            }
        }

        double average = (double)sum / (double)numbers.Count;
        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");
        Console.WriteLine("The sorted list is:");

        // Display each entry in the numbers list:
        numbers.ForEach(Console.WriteLine);
    }
}