using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    internal class Task03_Calculator : ITask
    {
        public string Title => "Задание 3: Калькулятор с обработкой деления на ноль";
        public string Description => "Принимать два числа и оператор (+ - * /), выводить результат.";
        public string[] Requirements => new string[]
        {
            "Оператор обрабатывать через switch.",
            "При делении на ноль — вывести сообщение об ошибке, не ронять приложение.",
            "Некорректный оператор — вывести «Неизвестная операция».",
            "Ввод чисел — через double.Parse или TryParse."
        };
        public void Run()
        {
            Console.WriteLine("Введите число Х: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число Y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите Действие (+, -, *, /): ");
            String z = Console.ReadLine();

            switch (z)
            {
                case "+":
                    var ResPlsu = x + y;
                    Console.WriteLine(ResPlsu);
                 break;
                case "-":
                    var ResMinus = x + y;
                    Console.WriteLine(ResMinus);
                    break;
                case "*":
                    var ResMultiply = x * y;
                    Console.WriteLine(ResMultiply);
                    break;
                case "/":
                    if(y == 0)
                    {
                        Console.WriteLine("Деление на ноль невозможно");
                        break;
                    }
                    var ResDivide = x / y;
                    Console.WriteLine(ResDivide);
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
        }
    }
}
