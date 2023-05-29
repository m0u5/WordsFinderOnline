using Newtonsoft.Json;

namespace WordsFinderOnline
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.Map("/CountWords", async (HttpContext httpContext) =>
            {
                using StreamReader reader = new StreamReader(httpContext.Request.Body);
                string text = await reader.ReadToEndAsync();
                
                var result = new WordsFinder.WordsFinder().CountWordsWithParallel(text);
                
                return JsonConvert.SerializeObject(result);
            });
            app.Map("/", ()=>
            
                "Hello world"
            );

            app.Run();
        }
        class RecievedText
        {
            public string Text { get; set; }
        }
    }
}