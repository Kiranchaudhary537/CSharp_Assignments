using System;
using System.Threading.Tasks;



namespace Assignment5
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var backgroundOperation = new BackgroundOperation();
            var kioskSystem = new KioskSystem(backgroundOperation);
            await kioskSystem.RunAsync();
        }
    }
}
