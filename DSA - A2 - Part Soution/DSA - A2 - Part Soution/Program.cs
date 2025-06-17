//Use the code in this class to prove that the SplitMix64 PRNG implemented is (Done)
//indeed correct and intractaable as described in Task 2 of the Assignment Brief

using DSA___A2___Part_Soution;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        SplitMix64 rng = new SplitMix64();

        //Generate 100 random numbers in range [1, 1000]
        List<ulong> randomNumbers = new List<ulong>();
        for (int i = 0; i < 100; i++)
        {
            ulong num = rng.Next(1, 1000);
            randomNumbers.Add(num);
        }

        ////to check the numbers generated
        //foreach (var num in randomNumbers)
        //{
        //    Console.Write($"{num} ");
        //}
        //Console.WriteLine("\n");

        //Checks if in range [1,1000](true or false) (has to be true)
        bool allInRange = randomNumbers.All(n => n >= 1 && n <= 1000);
        Console.WriteLine($"Numbers in range [1, 1000]: {allInRange}");

        //Checks for ascending order(true or false) (has to be false)
        bool isAscending = randomNumbers.SequenceEqual(randomNumbers.OrderBy(n => n));
        Console.WriteLine($"Ascending order: {isAscending}");

        //checks for descending order(true or false) (has to be false)
        bool isDescending = randomNumbers.SequenceEqual(randomNumbers.OrderByDescending(n => n));
        Console.WriteLine($"Descending order: {isDescending}");

        //displays the results of the analysis
        EmpiricalAnalysis();
    }

    //Making use of EmpricialAnalysis to demonstrate whether the PRNG is Intractable or not
    private static void EmpiricalAnalysis()
    {
        SplitMix64 rng = new SplitMix64();

        int[] numbers = { 1000, 10000, 100000, 1000000 };

        //repeats of the tests, this has been included as the test was producing reults of 0 which I wouldnt be able to plot on the
        //log log graph, hence the test is repeated 10 times and then the average of the results is taken to be plotted.
        int repeats = 10;
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Timings: ");

        for (int i = 0; i < 1000; i++)
            rng.Next(1, 1000);

        foreach (int number in numbers)
        {
            //used to check the time needed to generate the amount of numbers 
            var stopwatch = Stopwatch.StartNew();

            //this repeats the test 10 times
            for (int r = 0; r < repeats; r++)
            {
                //generate numbers within the range of [1,1000]
                for (int i = 0; i < number; i++)
                {
                    rng.Next(1, 1000);
                }
            }

            stopwatch.Stop();
            //takes the average timinigs
            double avgTimeMs = stopwatch.Elapsed.TotalMilliseconds / repeats;
            Console.WriteLine($"Generated {number} numbers in {avgTimeMs} ms over {repeats} runs ms");
        }
    }
}

