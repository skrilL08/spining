namespace CSharpPracticum.Tasks.Level1;
internal class Task13_WordCount : ITask
{
 public string Title => "Задание 13: Счётчик вхождений слов";
 public string Description => "Посчитать количество повторений каждого слова в тексте.";
 public string[] Requirements => new[] { "Использовать Dictionary<string, int>.", "Разбить текст по пробелам и знакам пунктуации.", "Привести слова к нижнему регистру.", "Вывести пары по убыванию количества." };
 public void Run() { Console.Write("Введите текст: "); string text=Console.ReadLine()??""; char[] separators=text.Where(char.IsPunctuation).Append(' ').Distinct().ToArray(); var words=text.Split(separators,StringSplitOptions.RemoveEmptyEntries); Dictionary<string,int> count=new(); foreach(string raw in words){string word=raw.ToLowerInvariant();if(count.ContainsKey(word))count[word]++;else count[word]=1;} foreach(var pair in count.OrderByDescending(x=>x.Value))Console.WriteLine($"{pair.Key} → {pair.Value}"); }
}

