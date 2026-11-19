using System.Diagnostics;
namespace CSharpPracticum.Tasks.Level3
{
    internal class Task38_CollectionsBenchmark : ITask
    {
        public string Title => "Задание 38: List и LinkedList";
        public string Description => "Сравнить вставку элементов в середину List и LinkedList.";
        public string[] Requirements => new[] { "Создать коллекции по 100 000 элементов.", "Вставить 1000 значений и измерить время." };
        public void Run()
        {
            var list = Enumerable.Range(0, 100000).ToList(); var linked = new LinkedList<int>(list); var timer = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++) list.Insert(list.Count / 2, -i); timer.Stop(); var listTime = timer.ElapsedMilliseconds;
            timer.Restart(); var node = linked.First; for (int i = 0; i < 50000; i++) node = node!.Next;
            for (int i = 0; i < 1000; i++) linked.AddBefore(node!, -i); timer.Stop();
            Console.WriteLine($"List: {listTime} мс"); Console.WriteLine($"LinkedList: {timer.ElapsedMilliseconds} мс");
            Console.WriteLine("В LinkedList вставка выполняется у найденного узла; поиск узла требует прохода по списку.");
        }
    }
}
