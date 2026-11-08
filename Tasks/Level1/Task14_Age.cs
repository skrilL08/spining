namespace CSharpPracticum.Tasks.Level1;
internal class Task14_Age : ITask
{
 public string Title => "Задание 14: Возраст по дате рождения";
 public string Description => "Вычислить точный возраст в годах, месяцах и днях.";
 public string[] Requirements => new[] { "Ввод через DateTime.TryParse.", "Учесть, наступил ли день рождения в этом году.", "Вывести X лет, Y месяцев, Z дней.", "Некорректная дата обрабатывается сообщением." };
 public void Run() { Console.Write("Введите дату рождения: "); if(!DateTime.TryParse(Console.ReadLine(),out DateTime birth)||birth.Date>DateTime.Today){Console.WriteLine("Некорректная дата рождения.");return;} DateTime today=DateTime.Today;int years=today.Year-birth.Year;DateTime anniversary;try{anniversary=birth.AddYears(years);}catch(ArgumentOutOfRangeException){anniversary=new DateTime(today.Year,2,28);}if(anniversary>today)years--;DateTime afterYears=birth.AddYears(years);int months=0;while(months<11&&afterYears.AddMonths(months+1)<=today)months++;DateTime afterMonths=afterYears.AddMonths(months);int days=(today-afterMonths).Days;Console.WriteLine($"{years} лет, {months} месяцев, {days} дней"); }
}
