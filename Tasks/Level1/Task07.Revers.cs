using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    internal class Task07 : ITask
    {
        public string Title => "Задание 7: Реверс строки без LINQ";
        public string Description => "Перевернуть введённую строку.";
        public string[] Requirements => new string[]
        {
            "Не использовать Array.Reverseи LINQ.",
            "Реализовать через цикл for от конца к началу (или через char[] и swap).",
            "Пустая строка и строка из одного символа — обрабатываются корректно."
        };
        public void Run()
        {
            Console.WriteLine("Введите строку: ");
            string line = Console.ReadLine() ;

            if (line == null)
            {
                Console.WriteLine($"");
            }
            string reverse = "";

            for (int i = line.Length - 1; i>= 0; i--)
            {
                reverse += line[i];
            }
            Console.WriteLine(reverse);
        }
    }
}

