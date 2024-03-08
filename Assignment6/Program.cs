using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task DownloadToFile(string url, string filePath)
    {
        //validation for url
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentNullException(nameof(url), "URL cannot be null or empty.");
        }

        //validation for filepath
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
        }

        //fetch and save from url
        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await fileStream.WriteAsync(System.Text.Encoding.UTF8.GetBytes(content));
                    Console.WriteLine($"Downloaded content from {url} and saved to {filePath}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error downloading content: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving content to file: {ex.Message}");
            }
        }
    }

    public static void Main(string[] args)
    {

        Console.WriteLine("Enter <URL> ex. https://youtube.com/ ");
        string url = Console.ReadLine(); ;
        Console.WriteLine("Enter <file_path> ex. youtube.txt ");
        string filePath = Console.ReadLine();

        DownloadToFile(url, filePath).Wait();
    }
}
