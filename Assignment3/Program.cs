using System;
using System.Collections.Generic;
using System.Linq;
using Assignment3;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {

            PrimeMinister pm = new PrimeMinister();

            // Add prime ministers
            pm.AddPrimeMinister(1998, "Atal Bihari Vajpayee");
            pm.AddPrimeMinister(2014, "Narendra Modi");
            pm.AddPrimeMinister(2004, "Manmohan Singh");

            // Find the Prime Minister of 2004
            Console.WriteLine("\nAnswer 1.");
            pm.FindPrimeMinisterByYear(2004);

            // Add the current Prime Minister
            Console.WriteLine("\nAnswer 2.");
            pm.AddPrimeMinister(2022, "Current Prime Minister");

            // Sort the dictionary by year and print
            Console.WriteLine("\nAnswer 3.");
            pm.PrintSortedPrimeMinister();
        }
    }
}
