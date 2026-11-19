namespace CSharpPracticum.Tasks.Level3
{
    internal class Task46_GitStash : ITask
    {
        public string Title => "Задание 46: Git stash"; public string Description => "Спрятать и восстановить незакоммиченные изменения.";
        public string[] Requirements => new[] { "Выполнить git stash, переключить ветку и выполнить git stash pop.", "Записать вывод git stash list до и после в git-notes.md." };
        public void Run() => Console.WriteLine("Выполните команды задания в отдельной рабочей копии; сохраните вывод до и после в git-notes.md.");
    }
}
