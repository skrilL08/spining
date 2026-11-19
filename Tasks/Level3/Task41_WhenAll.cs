using System.Diagnostics;
namespace CSharpPracticum.Tasks.Level3
{
    internal class Task41_WhenAll : ITask
    {
        public string Title => "Задание 41: Task.WhenAll";
        public string Description => "Сравнить последовательный и параллельный запуск десяти задач.";
        public string[] Requirements => new[] { "Каждая задача ждёт 500 мс и возвращает id.", "Измерить время обоих вариантов." };
        private static async Task<int> WorkAsync(int id) { await Task.Delay(500); return id; }
        public void Run() => RunAsync().GetAwaiter().GetResult();
        private static async Task RunAsync()
        {
            var timer = Stopwatch.StartNew(); var sequential = new List<int>();
            for (int i = 1; i <= 10; i++) sequential.Add(await WorkAsync(i)); timer.Stop(); long sequentialTime = timer.ElapsedMilliseconds;
            timer.Restart(); int[] parallel = await Task.WhenAll(Enumerable.Range(1, 10).Select(WorkAsync)); timer.Stop();
            Console.WriteLine($"Последовательно: {sequentialTime} мс"); Console.WriteLine($"Параллельно: {timer.ElapsedMilliseconds} мс");
            Console.WriteLine($"Результаты одинаковы: {sequential.SequenceEqual(parallel)}");
        }
    }
}
