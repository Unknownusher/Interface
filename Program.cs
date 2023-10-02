using System;

class Program {

    static void Main() {

        Computer computer = new Computer();

        Console.Write("Give a minimum number: ");
        int min = Convert.ToInt32(Console.ReadLine());

        Console.Write("Give a maximum number: ");
        int max = Convert.ToInt32(Console.ReadLine());

        int randomNumber = computer.GenerateNumber(min, max);

        while (computer.IsGuessing) {

            PASS:
                Console.Write($"\nGuess the number between {min} and {max}: ");
                int choice = Convert.ToInt32(Console.ReadLine());

            bool outOfBounds = choice < min || choice > max ? true : false;

            if (outOfBounds) {

                Console.WriteLine($"The number is not between the bounds of {min} and {max}.");
                goto PASS;

            }

            computer.EvaluateNumber(choice, randomNumber);

        }

        int counter = computer.Counter;

        Console.WriteLine($"\nYou guessed the number in {counter} tries.");
        Console.WriteLine("Thanks for playing!");

    }

}

interface IGenerator {

    public int GenerateNumber(int min, int max);
    public void EvaluateNumber(int choice, int randomNumber);

}

class Computer : IGenerator {

    bool _isGuessing = true;
    int _counter = 1;

    public bool IsGuessing { get => _isGuessing; set => _isGuessing = value; }
    public int Counter { get => _counter; set => _counter = value; }

    public Computer() {

        Console.WriteLine("Guess The Number");
        Console.WriteLine("----------------");

    }

    /// <summary>
    /// Generates a random number between the min and max values
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public int GenerateNumber(int min, int max) {

        System.Random random = new System.Random();

        int randomNumber = random.Next(min, max);

        return randomNumber;

    }

    /// <summary>
    /// Evaluates the user choice and compares it to the random number
    /// </summary>
    /// <param name="choice"></param>
    /// <param name="randomNumber"></param>
    public void EvaluateNumber(int choice, int randomNumber) {

        if (choice < randomNumber) {

            Console.Write("\nToo low, try again: ");
            Counter++;

            return;

        }

        if (choice > randomNumber) {

            Console.Write("\nToo high, try again: ");
            Counter++;

            return;

        }

        Console.WriteLine("\nYou Won!");
        IsGuessing = false;

    }

}