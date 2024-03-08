using System;
using System.Threading.Tasks;

public class KioskSystem
{
    private readonly BackgroundOperation _backgroundOperation;

    public KioskSystem(BackgroundOperation backgroundOperation)
    {
        _backgroundOperation = backgroundOperation;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\nAssignment5 Menu:");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                break;
            }

            string message = "";
            switch (choice)
            {
                case "1":
                    message = "Hello World";
                    break;
                case "2":
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case "3":
                    message = Environment.OSVersion.VersionString;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            // Start writing to file 
            Console.WriteLine("Writing data to file. Please wait...");
            _backgroundOperation.WriteToFileAsync(message);

        }
    }
}

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000);
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        var backgroundOperation = new BackgroundOperation();
        var kioskSystem = new KioskSystem(backgroundOperation);
        await kioskSystem.RunAsync();
    }
}
