using System.Diagnostics;
namespace CSharpPracticum.Tasks.Level3
{
    internal class Task37_Fibonacci : ITask
    {
        public string Title => "Задание 37: Мемоизация Фибоначчи";
        public string Description => "Сравнить обычную рекурсию и кэширование результатов в Dictionary.";
        public string[] Requirements => new[] { "Замерить время для N = 35 через Stopwatch.", "Вывести результаты и время обоих способов." };
        private static long Fibonacci(int n) => n < 2 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
        private static long FibonacciCached(int n, Dictionary<int, long> cache)
        {
            if (n < 2) return n;
            if (cache.TryGetValue(n, out long value)) return value;
            value = FibonacciCached(n - 1, cache) + FibonacciCached(n - 2, cache); cache[n] = value; return value;
        }
        public void Run()
        {
            const int n = 35; var timer = Stopwatch.StartNew(); long simple = Fibonacci(n); timer.Stop(); var simpleTime = timer.Elapsed;
            timer.Restart(); long cached = FibonacciCached(n, new Dictionary<int, long>()); timer.Stop();
            Console.WriteLine($"Обычная рекурсия: {simple}, {simpleTime.TotalMilliseconds:F2} мс");
            Console.WriteLine($"Словарь: {cached}, {timer.Elapsed.TotalMilliseconds:F2} мс");
            Console.WriteLine($"Разница: {simpleTime.TotalMilliseconds - timer.Elapsed.TotalMilliseconds:F2} мс");
        }
    }
}
