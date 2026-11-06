using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    internal class Task02_Paremens : ITask
    {
        public string Title => "Задание 2: Переменные примитивных типов";
        public string Description => "Объявить переменные всех примитивных типов и вывести их значения и типы.";
        public string[] Requirements => new string[]
        {
            "Объявить минимум:int,long,double,float,decimal,bool,char,string.",
            "Для каждой переменной вывести значение и GetType().Name.",
            "decimal— с суффиксомm,float— сf."
        };
        public void Run()
        {
            int intnum = 42;
            long longnum = 1234567890123456789;
            double doublenum = 12.3;
            float floatnub = 12.3f;
            decimal decimalnub = 123m;
            bool boolnub = true;
            char chartxt = 'x';
            string srtingtxt = "qwerty";


            Console.WriteLine(intnum + " => " + intnum.GetType().Name);
            Console.WriteLine(longnum + " => " + longnum.GetType().Name);
            Console.WriteLine(doublenum + " => " + doublenum.GetType().Name);
            Console.WriteLine(floatnub + " => " + floatnub.GetType().Name);
            Console.WriteLine(decimalnub + " => " + decimalnub.GetType().Name);
            Console.WriteLine(boolnub + " => " + boolnub.GetType().Name);
            Console.WriteLine(chartxt + " => " + chartxt.GetType().Name);
            Console.WriteLine(srtingtxt + " => " + srtingtxt.GetType().Name);


        }
    }
}

