using System;
using System.Collections.Generic;
using System.Linq;

class primeMinister
{
    Dictionary<int, string> primeMinisters;
    public primeMinister()
    {
        primeMinisters = new Dictionary<int, string>();
    }

    public void FindPrimeMinisterByYear(int year)
    {
        if (primeMinisters.ContainsKey(year))
        {
            Console.WriteLine($"Prime Minister of 2004: {primeMinisters[2004]}");
        }
        else
        {
            Console.WriteLine("No Prime Minister found for the year 2004.");
        }
    }
    public void AddPrimeMinister(int year, string name)
    {
        primeMinisters.Add(year, name);
        Console.WriteLine($"Prime Minister added for year ${year}");
    }

    public void PrintSortedPrimeMinister()
    {
        List<int> years = new List<int>(primeMinisters.Keys);
        years.Sort();

        Console.WriteLine("Prime Ministers sorted by year:");
        foreach (int year in years)
        {
            Console.WriteLine($"{year}: {primeMinisters[year]}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {

        primeMinister pm = new primeMinister();

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
