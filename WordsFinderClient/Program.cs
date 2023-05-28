using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace WordsFinderClient
{
    internal class Program
    {
        static HttpClient httpClient = new HttpClient();
        static async Task Main()
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();
            Console.Write("Введите путь к результату: ");
            string resultPath = Console.ReadLine();
            string text = File.ReadAllText(filePath);

            var content = JsonContent.Create(text);
           
           using var response = await httpClient.PostAsync("http://localhost:7280/CountWords", content);
            
            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();
            WriteToFile(resultPath, result);
        }
        private static void WriteToFile(string resultPath, Dictionary<string, int> result)
        {
            try
            {


                var sw = new StreamWriter(resultPath, false, Encoding.Unicode);
                foreach (var res in result)
                {
                    sw.WriteLine(res.Key + " " + res.Value);
                }
                sw.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }


        }
    }
}