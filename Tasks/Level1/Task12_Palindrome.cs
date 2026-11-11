namespace CSharpPracticum.Tasks.Level1;
internal class Task12_Palindrome : ITask
{
 public string Title => "Задание 12: Палиндром";
 public string Description => "Проверить строку на палиндром без учёта регистра, пробелов и пунктуации.";
 public string[] Requirements => new[] { "Игнорировать регистр, пробелы и знаки пунктуации.", "Не использовать LINQ Reverse.", "Пустая строка и строка из одного символа — палиндром." };
 public void Run() { Console.Write("Введите строку: "); string s=Console.ReadLine()??""; Console.WriteLine(IsPalindrome(s)?"Палиндром":"Не палиндром"); }
 private static bool IsPalindrome(string s) { int l=0,r=s.Length-1; while(l<r){while(l<r&&!char.IsLetterOrDigit(s[l]))l++;while(l<r&&!char.IsLetterOrDigit(s[r]))r--;if(char.ToLowerInvariant(s[l])!=char.ToLowerInvariant(s[r]))return false;l++;r--;}return true; }
}
