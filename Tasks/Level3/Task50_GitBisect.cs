namespace CSharpPracticum.Tasks.Level3
{
    internal class Task50_GitBisect : ITask
    {
        public string Title => "Задание 50: Git bisect"; public string Description => "Найти коммит, который внёс ошибку, с помощью git bisect.";
        public string[] Requirements => new[] { "На учебной ветке создать последовательность коммитов с одним намеренно ошибочным.", "Найти его через bisect, выполнить git bisect reset и записать вывод." };
        public void Run() => Console.WriteLine("Проводите bisect только в учебной ветке, затем сохраните результат и выполните git bisect reset.");
    }
}
