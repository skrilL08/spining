using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    public class Task01_HelloWorld : ITask
    {
        public string Title => "Задание 1: Hello, World!";
        public string Description => "Напишите программу, которая выводит на экран сообщение 'Hello, World!' с добавлением даты.";
        public string[] Requirements => new string[]
        {
            "Использовать метод Console.WriteLine для вывода сообщения.",
            "Дату получить черезDateTime.Now, отформатировать какdd.MM.yyyy.",
            "Вывести две строки: приветствие и дату."
        };
        public void Run()
        {
            
            Console.WriteLine("Hello, World!"+ DateTime.Now.ToString("dd.MM.yyyy"));
        }
    }
    
}
