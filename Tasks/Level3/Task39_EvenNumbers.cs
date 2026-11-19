namespace CSharpPracticum.Tasks.Level3
{
    internal class Task39_EvenNumbers : ITask
    {
        public string Title => "Задание 39: Генератор чётных чисел";
        public string Description => "Создать ленивую последовательность через yield return.";
        public string[] Requirements => new[] { "GetEvenNumbers возвращает чётные числа до max.", "Показать пошаговое выполнение в foreach." };
        private static IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int number = 0; number <= max; number += 2) { Console.WriteLine($"Генератор подготовил {number}"); yield return number; }
        }
        public void Run() { foreach (int number in GetEvenNumbers(10)) Console.WriteLine($"Получено: {number}"); }
    }
}
