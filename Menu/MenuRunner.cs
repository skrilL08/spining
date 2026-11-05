using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Menu
{
    public class MenuRunner
    {
        public static void Start()
        {
            Console.WriteLine("=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 - Базовые (задания 1-15)");
            Console.WriteLine("2. Уровень 2 - Продвинутые (задания 16-35)");
            Console.WriteLine("3. Уровень 3 - Экспертные (задания 36-50)");
            Console.WriteLine("4. Выход");

            Console.Write("Выберите уровень (1-4): ");
            var choice = (Console.ReadLine());
            LevelMenu levelMenu = new LevelMenu();
            
            if (choice == "4" || Convert.ToString(choice) == "q" || int.Parse(choice) == 0)
            {
                Console.WriteLine("Выход из программы.");
                Environment.Exit(0);
            }
            else if (int.Parse(choice) > 4)
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали  недопустимое значение. Выберите от 1-4.\n");
                MenuRunner.Start();
            }

            levelMenu.Show(int.Parse(choice));
        }
    }
}
