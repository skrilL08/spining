using CSharpPracticum.Common;
using CSharpPracticum.Tasks;
using System.Reflection;

namespace CSharpPracticum.Menu
{
    public class LevelMenu
    {
        private List<ITask> GetTasks(int level)
        {
            List<ITask> tasks = new List<ITask>();

            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                if (type.IsClass &&
                    typeof(ITask).IsAssignableFrom(type) &&
                    type.Namespace == $"CSharpPracticum.Tasks.Level{level}")
                {
                    ITask task = (ITask)Activator.CreateInstance(type)!;

                    tasks.Add(task);
                }
            }

            return tasks.OrderBy(task => GetTaskNumber(task.Title)).ToList();
        }

        private static int GetTaskNumber(string title)
        {
            string[] parts = title.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            return parts.Length > 1 && int.TryParse(parts[1].TrimEnd(':', '.'), out int number)
                ? number
                : int.MaxValue;
        }

        private static string GetTaskName(string title)
        {
            string[] parts = title.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            return parts.Length == 3 ? parts[2] : title;
        }
        public void Show(int level)
        {
            

            switch (level)
            {
                case 1:
                    Console.WriteLine("=== Уровень 1 - Базовые (задания 1-15) ===");

                    var tasksEasy = GetTasks(1);

                    for (int i = 0; i < tasksEasy.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {GetTaskName(tasksEasy[i].Title)}");
                    }

                    Console.WriteLine("\n0. Назад");

                    var choiceEasy = Console.ReadLine();



                    if (choiceEasy == "0")
                    {
                        Console.Clear();
                        MenuRunner.Start();
                    }
                    else if (!int.TryParse(choiceEasy, out int number) || number < 1 || number > tasksEasy.Count)
                    {
                        Console.Clear();
                        
                        Console.WriteLine("Вы выбрали недопустимое значение. Выберите от 1-15.\n");
                        

                        goto case 1;
                    }

                    else
                    {
                        Console.Clear();
                        ITask selectedTask = tasksEasy[number - 1];

                        TaskInfoAttribute.Show(selectedTask);

                        selectedTask.Run();

                        Console.WriteLine("\nНажмите Enter для возврата в меню...");
                        Console.ReadLine();

                        Console.Clear();

                        goto case 1;
                    }


                        break;
                    


                case 2:
                    Console.WriteLine("=== Уровень 2 - Продвинутые (задания 16-35) ===");

                    var tasksMedium = GetTasks(2);

                    for (int i = 0; i < tasksMedium.Count; i++)
                    {
                        Console.WriteLine($"{i + 16}. {GetTaskName(tasksMedium[i].Title)}");
                    }

                    Console.WriteLine("\n0. Назад");

                    var choiceMedium = Console.ReadLine();

                    if (choiceMedium == "0")
                    {
                        Console.Clear();
                        MenuRunner.Start();
                    }
                    else if (!int.TryParse(choiceMedium, out int number) || number < 16 || number >= 16 + tasksMedium.Count)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы выбрали недопустимое значение. Выберите задание от 16 до 34.\n");
                        Console.ResetColor();

                        goto case 2;
                    }

                    else
                    {
                        Console.Clear();
                        ITask selectedTask = tasksMedium[number - 16];

                        TaskInfoAttribute.Show(selectedTask);

                        selectedTask.Run();

                        Console.WriteLine("\nНажмите Enter для возврата в меню...");
                        Console.ReadLine();

                        Console.Clear();

                        goto case 2;
                    }

                    break;



                case 3:
                    Console.WriteLine("=== Уровень 3 - Экспертные (задания 36-50) ===");

                    var taskshard = GetTasks(3);

                    for (int i = 0; i < taskshard.Count; i++)
                    {
                        Console.WriteLine($"{i + 36}. {GetTaskName(taskshard[i].Title)}");
                    }

                    Console.WriteLine("\n0. Назад");

                    var choiceHard = Console.ReadLine();

                    if (choiceHard == "0")
                    {
                        Console.Clear();
                        MenuRunner.Start();
                    }
                    else if (!int.TryParse(choiceHard, out int number) || number < 36 || number >= 36 + taskshard.Count)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы выбрали недопустимое значение. Выберите задание от 36 до 50.\n");
                        Console.ResetColor();

                        goto case 3;
                    }

                    else
                    {
                        Console.Clear();
                        ITask selectedTask = taskshard[number - 36];

                        TaskInfoAttribute.Show(selectedTask);

                        selectedTask.Run();

                        Console.WriteLine("\nНажмите Enter для возврата в меню...");
                        Console.ReadLine();

                        Console.Clear();

                        goto case 3;
                    }
                    break;

                default:

                    Console.WriteLine("Вы выбрали недопустимое значение. Выберите от 1-3.");

                    break;
                }
            }
        

    }
    


}
