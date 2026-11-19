using System.Text.Json;
namespace CSharpPracticum.Tasks.Level3
{
    internal class TaskItem { public int Id { get; set; } public string Title { get; set; } = ""; public bool IsDone { get; set; } }
    internal class TaskRepository
    {
        private readonly string path = Path.Combine(AppContext.BaseDirectory, "tasks.json");
        public List<TaskItem> Load() { if (!File.Exists(path)) return new(); try { return JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(path)) ?? new(); } catch (JsonException) { Console.WriteLine("Файл задач повреждён. Начинаем с пустого списка."); return new(); } }
        public void Save(List<TaskItem> items) => File.WriteAllText(path, JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true }));
    }
    internal class TaskService
    {
        private readonly TaskRepository repository = new(); private List<TaskItem> items;
        public TaskService() { items = repository.Load(); }
        public IReadOnlyList<TaskItem> All => items;
        public TaskItem Add(string title) { if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Название не должно быть пустым."); var item = new TaskItem { Id = items.Count == 0 ? 1 : items.Max(x => x.Id) + 1, Title = title.Trim() }; items.Add(item); Save(); return item; }
        public bool Complete(int id) { var item = items.FirstOrDefault(x => x.Id == id); if (item == null) return false; item.IsDone = true; Save(); return true; }
        public bool Delete(int id) { var item = items.FirstOrDefault(x => x.Id == id); if (item == null) return false; items.Remove(item); Save(); return true; }
        private void Save() => repository.Save(items);
    }
    internal class Task44_TodoList : ITask
    {
        public string Title => "Задание 44: Todo List и JSON";
        public string Description => "Управлять списком задач и сохранять его между запусками.";
        public string[] Requirements => new[] { "Добавление, просмотр, завершение и удаление задач.", "Хранить данные в tasks.json и обрабатывать неправильный ввод." };
        public void Run()
        {
            var service = new TaskService();
            while (true)
            {
                Console.WriteLine("1. Показать  2. Добавить  3. Завершить  4. Удалить  0. Выход"); var choice = Console.ReadLine(); if (choice == "0") return;
                if (choice == "1") foreach (var item in service.All) Console.WriteLine($"{item.Id}. [{(item.IsDone ? "x" : " ")}] {item.Title}");
                else if (choice == "2") { Console.Write("Название: "); try { var item = service.Add(Console.ReadLine() ?? ""); Console.WriteLine($"Добавлено: {item.Id}"); } catch (ArgumentException error) { Console.WriteLine(error.Message); } }
                else if (choice == "3" || choice == "4") { Console.Write("Номер задачи: "); if (int.TryParse(Console.ReadLine(), out int id)) Console.WriteLine((choice == "3" ? service.Complete(id) : service.Delete(id)) ? "Готово." : "Задача не найдена."); else Console.WriteLine("Введите целое число."); }
                else Console.WriteLine("Неизвестный пункт меню.");
            }
        }
    }
}
