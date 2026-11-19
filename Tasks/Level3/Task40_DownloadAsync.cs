namespace CSharpPracticum.Tasks.Level3
{
    internal class Task40_DownloadAsync : ITask
    {
        public string Title => "Задание 40: async/await и исключения";
        public string Description => "Имитировать загрузку и обработать пустой адрес.";
        public string[] Requirements => new[] { "Использовать Task.Delay и ArgumentException.", "Показать успешный и ошибочный вызов." };
        private static async Task<string> DownloadAsync(string url) { if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("Адрес не должен быть пустым.", nameof(url)); await Task.Delay(1000); return $"Загружено: {url}"; }
        public void Run() => RunAsync().GetAwaiter().GetResult();
        private static async Task RunAsync()
        {
            try { Console.WriteLine(await DownloadAsync("https://example.com")); Console.WriteLine(await DownloadAsync("")); }
            catch (ArgumentException error) { Console.WriteLine($"Ошибка обработана: {error.Message}"); }
        }
    }
}
