using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    internal class Task06_Sum : ITask
    {
        public string Title => "Задание 6: Сумма цифр числа (строка + арифметика)";
        public string Description => "Найти сумму цифр введённого числа (например, 1234 => 10).";
        public string[] Requirements => new string[]
        {
            "Способ 1 (строка): число => ToString() => пройти по символам => int.Parse каждой цифры.",
            "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.",
            "Оба способа оформить отдельными методами.",
            "Отрицательные числа — брать модуль."
        };

        private static int Write()
        {
            int frst = int.Parse(Console.ReadLine());

            int num = 0;
            if (frst > 0)
            {
                num += frst;
            }
            else
            {
                num += Math.Abs(frst);
            }
            return num;
        }

        public void Run()
        {
            Console.WriteLine("Введите число для суммы цифр: ");

            int number = Write();

            Console.WriteLine($"Способ 1: {Method1(number)}");
            Console.WriteLine($"Способ 2: {Method2(number)}");
        }
        
        private static int Method1(int num)
        {
            string frststr = Convert.ToString(num);

            int resfrst = 0;
            for (int i = 0; i < frststr.Length; i++)
            {
                int def = int.Parse(frststr[i].ToString());
                resfrst += def;
            }
            return resfrst;
        }
        private static int Method2(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10; num /= 10;
            }
            return sum;
        }
    }
}
