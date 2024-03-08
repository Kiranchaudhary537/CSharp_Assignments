namespace Assignment5
{
    public class BackgroundOperation
    {
        public async Task WriteToFileAsync(string message)
        {
            await Task.Delay(3000);
            await File.WriteAllTextAsync("tmp.txt", message);
        }
    }

}