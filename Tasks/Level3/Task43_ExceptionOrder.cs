namespace CSharpPracticum.Tasks.Level3
{
    internal class Task43_ExceptionOrder : ITask
    {
        private sealed class CustomException : Exception { public CustomException(string message) : base(message) { } }
        public string Title => "Задание 43: Порядок обработки исключений";
        public string Description => "Показать отдельную обработку разных типов исключений и finally.";
        public string[] Requirements => new[] { "Обработать FormatException, DivideByZeroException и собственное исключение.", "finally выполняется для каждого сценария." };
        private static void Perform(int scenario)
        {
            if (scenario == 1) throw new FormatException("Некорректный формат.");
            if (scenario == 2) throw new DivideByZeroException("Деление на ноль.");
            throw new CustomException("Пользовательская ошибка.");
        }
        public void Run()
        {
            for (int i = 1; i <= 3; i++)
            {
                try { Perform(i); }
                catch (FormatException error) { Console.WriteLine(error.Message); }
                catch (DivideByZeroException error) { Console.WriteLine(error.Message); }
                catch (CustomException error) { Console.WriteLine(error.Message); }
                finally { Console.WriteLine("Завершено."); }
            }
            Console.WriteLine("Сначала проверяются конкретные типы исключений, затем более общие.");
        }
    }
}
