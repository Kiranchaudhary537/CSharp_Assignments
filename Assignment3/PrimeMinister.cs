
namespace Assignment3
{
    class PrimeMinister
    {
        Dictionary<int, string> primeMinisters;
        public PrimeMinister()
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

}