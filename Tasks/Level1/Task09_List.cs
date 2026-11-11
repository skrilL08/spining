using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    internal class Task09_List : ITask
    {
        public string Title => "Задание 9: Массивы: min/max/sum/avg";
        public string Description => "для массива чисел найти минимум, максимум, сумму и среднее.";
        public string[] Requirements => new string[]
        {
            "Заполнить массив (например, случайными числами 1–100, размер 20).",
            "Реализовать без LINQ (Min/Max/Sum/Average запрещены).",
            "Оформить 4 отдельных метода.",
            "Пустой массив — обработать (вернуть ошибку или 0, но не падать)."
        };

        private int[] list = new int[20];

        public void Run()
        {
            Random random = new Random();

            for (int i = 0; i < list.Length; i++) 
            {
                list[i] = random.Next(1, 101);
            }


            if (list.Length == 0)
            {
                Console.WriteLine("Пустой массив");
                return;
            }

            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine($"Минимальное: {Min(list)}");
            Console.WriteLine($"Максимальное: {Max(list)}");
            Console.WriteLine($"Сумма чисель: {Sum(list)}");
            Console.WriteLine($"Среднее значение: {Avg(list)}");

        }

        private static int Min(int[] list)
        {
            int min = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i] < min)
                {
                    min = list[i];
                }
            }

            if (list.Length == 0)
            { 
                return 0;
            }

            return min;
        }

        private static int Max(int[] list)
        {
            int max = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                }
            }

            if (list.Length == 0)
            {
                return 0;
            }

            return max;
        }

        private static int Sum(int[] list)
        {
            int sum = 0;
            for (int i = 0; i < list.Length; i++)
            {
                sum += list[i];
            }

            if (list.Length == 0)
            {
                return 0;
            }

            return sum;
        }
        private static int Avg(int[] list)
        {
            if (list.Length == 0)
            {
                return 0;
            }

            int avg = Sum(list) / list.Length;
            return avg;
        }
    }

}

