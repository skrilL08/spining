namespace CSharpPracticum.Tasks.Level3
{
    internal class Task48_GitTag : ITask
    {
        public string Title => "Задание 48: Git tag"; public string Description => "Создать аннотированный тег версии v1.0.0.";
        public string[] Requirements => new[] { "Создать тег git tag -a v1.0.0 -m \"Release v1.0.0\".", "Сохранить git tag и git show v1.0.0 в git-notes.md." };
        public void Run() => Console.WriteLine("Создайте тег на стабильном коммите и сохраните вывод git tag и git show в git-notes.md.");
    }
}
