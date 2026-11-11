using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    internal class Task08_FizzBuzz : ITask
    {
        public string Title => "Задание 8: FizzBuzz 1–100";
        public string Description => "Вывести числа от 1 до 100 с заменами.";
        public string[] Requirements => new string[]
        {
            "Кратно 3 => Fizz.",
            "Кратно 5 => Buzz.",
            "Кратно 15 => FizzBuzz.",
            "Иначе — само число.",
            "Порядок проверок: сначала 15, потом 3 и 5."
        };
        public void Run()
        {
            string res = "";

            for (int i = 1; i <= 99; i++)
            {
                if(i % 15 ==0)
                {
                    res += "FizzBuzz";
                    i++;
                }

                if (i % 3 == 0)
                {
                    res += "Fizz";
                    i++;
                }

                if (i % 5 == 0)
                {
                    res += "Buzz";
                    i++;
                }

                
                if(i == 101)
                {
                    break;
                }
                res += i;
            }

            Console.WriteLine(res);
        }
    }
}
