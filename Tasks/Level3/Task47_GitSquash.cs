namespace CSharpPracticum.Tasks.Level3
{
    internal class Task47_GitSquash : ITask
    {
        public string Title => "Задание 47: Git rebase -i"; public string Description => "Объединить четыре небольших коммита в один.";
        public string[] Requirements => new[] { "Создать feature/squash-demo и четыре коммита.", "Выполнить git rebase -i HEAD~4 и сохранить log до и после." };
        public void Run() => Console.WriteLine("Используйте отдельную ветку feature/squash-demo и сохраните оба git log в git-notes.md.");
    }
}
