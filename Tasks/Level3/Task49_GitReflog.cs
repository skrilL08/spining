namespace CSharpPracticum.Tasks.Level3
{
    internal class Task49_GitReflog : ITask
    {
        public string Title => "Задание 49: Git reflog"; public string Description => "Восстановить удалённый коммит по reflog.";
        public string[] Requirements => new[] { "Создать коммит, переместить HEAD назад и найти коммит в reflog.", "Восстановить его и сохранить reflog и log в git-notes.md." };
        public void Run() => Console.WriteLine("Это упражнение меняет указатель истории. Выполните reset только в учебной ветке и сохраните вывод в git-notes.md.");
    }
}
