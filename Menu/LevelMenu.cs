using CSharpPracticum.Common;
using CSharpPracticum.Tasks;
using System.Reflection;

namespace CSharpPracticum.Menu
{
    public class LevelMenu
    {
        private List<ITask> GetTasks(int level)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && typeof(ITask).IsAssignableFrom(t) && t.Namespace == $"CSharpPracticum.Tasks.Level{level}").Select(t => (ITask)Activator.CreateInstance(t)!).ToList();
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
                        Console.WriteLine($"{i+1}. {tasksEasy[i].Title.Replace($"Задание {i+1}: ", "")}");
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы выбрали недопустимое значение. Выберите от 1-15.\n");
                        Console.ResetColor();

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
                        Console.WriteLine($"{i + 1}. {tasksMedium[i].Title.Replace($"Задание {i + 1}: ", "")}");
                    }

                    Console.WriteLine("\n0. Назад");

                    var choiceMedium = Console.ReadLine();

                    if (choiceMedium == "0")
                    {
                        Console.Clear();
                        MenuRunner.Start();
                    }
                    else if (!int.TryParse(choiceMedium, out int number) || number < 1 || number > tasksMedium.Count)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы выбрали недопустимое значение. Выберите от 1-19.\n");
                        Console.ResetColor();

                        goto case 2;
                    }

                    else
                    {
                        Console.Clear();
                        ITask selectedTask = tasksMedium[number - 1];

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
                        Console.WriteLine($"{i + 1}. {taskshard[i].Title.Replace($"Задание {i + 1}: ", "")}");
                    }

                    Console.WriteLine("\n0. Назад");

                    var choiceHard = Console.ReadLine();

                    if (choiceHard == "0")
                    {
                        Console.Clear();
                        MenuRunner.Start();
                    }
                    else if (!int.TryParse(choiceHard, out int number) || number < 1 || number > taskshard.Count)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы выбрали недопустимое значение. Выберите от 1-14.\n");
                        Console.ResetColor();

                        goto case 3;
                    }

                    else
                    {
                        Console.Clear();
                        ITask selectedTask = taskshard[number - 1];

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