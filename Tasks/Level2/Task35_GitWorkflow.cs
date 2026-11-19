namespace CSharpPracticum.Tasks.Level2
{
    internal class Task35_GitWorkflow : ITask
    {
        public string Title => "Задание 35: Git — PR и rebase";
        public string Description => "Проверить настройки репозитория, Pull Request и объединение коммитов через интерактивный rebase.";
        public string[] Requirements => new[] { "Проверить .gitignore и .editorconfig.", "Создать feature/task-35 и Pull Request.", "Создать feature/rebase-demo, объединить три коммита и записать результат в git-notes.md." };
        public void Run()
        {
            Console.WriteLine("Рабочий сценарий задания записан в git-notes.md, раздел Task 35.");
            Console.WriteLine("После выполнения PR и rebase сохраните вывод git log --oneline.");
        }
    }
}
