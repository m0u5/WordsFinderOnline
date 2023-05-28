    namespace WordsFinderOnline
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.MapPost("/CountWords", (RecievedText text) =>
            {

                var result = new WordsFinder.WordsFinder().CountWordsWithParallel(text.Text);
                return Results.Json(result);
            });

            app.Run();
        }
        class RecievedText
        {
            public string Text { get; set; }
        }
    }
}