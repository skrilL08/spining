using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    internal class Task04_Parity : ITask
    {
        public string Title => "Задание 4: Чётность числа (два способа)";
        public string Description => "Oпределить, чётное ли введённое число.";
        public string[] Requirements => new string[]
        {
            "Способ 1: через % 2 == 0.",
            "Способ 2: через тернарный оператор? :.",
            "Оба способа реализовать отдельными методами.",
            "Вывести результат обоих способов."
        };

        private static int Write()
        {
            Console.WriteLine("Ведите число: ");
            int x = Convert.ToInt32(Console.ReadLine());
            return x;
        }

        public void Run()
        {
            int x = Write();

            Console.WriteLine($"Способ 1: {Method1(x)}");
            Console.WriteLine($"Способ 2: {Method2(x)}");
        }

        private static bool Method1(int x) 
        {
            double resfrst = x % 2;
            bool res = false;
            if (resfrst == 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }

        private static bool Method2(int x)
        {
            bool resscnd = x % 2 == 0 ? true : false;
            return resscnd;
        }

    }
}
