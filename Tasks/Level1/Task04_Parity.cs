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
        public void Run()
        {
            Console.WriteLine("Ведите число: ");
            int x = Convert.ToInt32(Console.ReadLine());

            double resfrst = x % 2;
            bool resscnd = x % 2 == 0 ? true : false ;

            if (resfrst == 0)
            {
                Console.WriteLine($"Способ 1: {resfrst} => True");
            }
            else
            {
                Console.WriteLine($"Способ 1: {resfrst} => False");
            }
            Console.WriteLine($"Способ 2: {resscnd}");


            
        }
    }
}
