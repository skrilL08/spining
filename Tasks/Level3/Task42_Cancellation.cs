namespace CSharpPracticum.Tasks.Level3
{
    internal class Task42_Cancellation : ITask
    {
        public string Title => "Задание 42: CancellationToken";
        public string Description => "Отменить долгую операцию через две секунды.";
        public string[] Requirements => new[] { "Выполнить десять задержек по 500 мс.", "Обработать OperationCanceledException." };
        private static async Task LongOperationAsync(CancellationToken token) { for (int i = 1; i <= 10; i++) { await Task.Delay(500, token); Console.WriteLine($"Шаг {i}"); } }
        public void Run() => RunAsync().GetAwaiter().GetResult();
        private static async Task RunAsync()
        {
            using var source = new CancellationTokenSource(); Task operation = LongOperationAsync(source.Token); await Task.Delay(2000); source.Cancel();
            try { await operation; } catch (OperationCanceledException) { Console.WriteLine("Операция отменена."); }
        }
    }
}
