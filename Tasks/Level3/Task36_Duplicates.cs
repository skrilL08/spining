namespace CSharpPracticum.Tasks.Level3
{
    internal class Task36_Duplicates : ITask
    {
        public string Title => "Задание 36: Дубликаты в List";
        public string Description => "Найти повторяющиеся числа через HashSet и LINQ GroupBy.";
        public string[] Requirements => new[] { "Оформить оба способа отдельными методами.", "Сравнить наборы найденных дубликатов." };
        private static List<int> FindWithHashSet(List<int> numbers)
        {
            var seen = new HashSet<int>(); var duplicates = new HashSet<int>();
            foreach (int number in numbers) { if (seen.Contains(number)) duplicates.Add(number); else seen.Add(number); }
            return duplicates.OrderBy(x => x).ToList();
        }
        private static List<int> FindWithLinq(List<int> numbers) => numbers.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).OrderBy(x => x).ToList();
        public void Run()
        {
            var numbers = new List<int> { 1, 4, 2, 4, 3, 1, 7, 2, 2 };
            var first = FindWithHashSet(numbers); var second = FindWithLinq(numbers);
            Console.WriteLine($"Список: {string.Join(", ", numbers)}");
            Console.WriteLine($"HashSet: {string.Join(", ", first)}");
            Console.WriteLine($"GroupBy: {string.Join(", ", second)}");
            Console.WriteLine($"Результаты совпадают: {first.SequenceEqual(second)}");
        }
    }
}
