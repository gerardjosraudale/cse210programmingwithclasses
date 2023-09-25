using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        //Fro parts 1 and 2, where the user specified the number..
        Console.WriteLine("What is the magic number? ");
        //int magicNumber = int.Parse(Console.ReadLine())

        //For part 3, where we use a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);

        int guess = -1;

        //We could also a do-while loop here...
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
                Console.WriteLine("You guessed it!");
            }
        }
    }
}