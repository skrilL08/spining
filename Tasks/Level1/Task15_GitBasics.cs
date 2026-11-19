namespace CSharpPracticum.Tasks.Level1
{
    internal class Task15_GitBasics : ITask
    {
        public string Title => "Задание 15: Git — ветки и конфликт";
        public string Description => "Практика создания репозитория, веток, merge и разрешения конфликта в README.md. Результат записывается в git-notes.md.";
        public string[] Requirements => new[] { "Создать 2–3 коммита и ветку feature/git-basics.", "Смоделировать конфликт в README.md и разрешить его.", "Сохранить git log --graph --oneline --all в git-notes.md." };
        public void Run()
        {
            Console.WriteLine("Задание выполнено в истории этого репозитория.");
            Console.WriteLine("Запись и команды см. в git-notes.md, раздел Task 15.");
            Console.WriteLine("Команда для просмотра истории: git log --graph --oneline --all");
        }
    }
}
