using System.Diagnostics;

namespace CSharpPracticum.Tasks.Level1;

internal class Task10_Sort : ITask
{
    public string Title => "Задание 10: Сортировка пузырьком + вставками";
    public string Description => "Отсортировать массив двумя алгоритмами и сравнить время.";
    public string[] Requirements => new[] { "BubbleSort и InsertionSort реализовать отдельно, без LINQ и Array.Sort.", "Измерить время Stopwatch на 10 000 элементов.", "Вывести оба времени." };
    public void Run()
    {
        int[] source = new int[10000];
        for (int i = 0; i < source.Length; i++) source[i] = Random.Shared.Next();
        int[] bubble = (int[])source.Clone(), insertion = (int[])source.Clone();
        Stopwatch watch = Stopwatch.StartNew(); BubbleSort(bubble); watch.Stop(); long bubbleTime = watch.ElapsedMilliseconds;
        watch.Restart(); InsertionSort(insertion); watch.Stop();
        Console.WriteLine($"Пузырьком: {bubbleTime} мс"); Console.WriteLine($"Вставками: {watch.ElapsedMilliseconds} мс");
        bool same = true;
        for (int i = 0; i < bubble.Length; i++)
            if (bubble[i] != insertion[i]) same = false;
        Console.WriteLine($"Массивы совпадают: {same}");
    }
    private static void BubbleSort(int[] a) { for (int i=0;i<a.Length-1;i++) for(int j=0;j<a.Length-i-1;j++) if(a[j]>a[j+1]) (a[j],a[j+1])=(a[j+1],a[j]); }
    private static void InsertionSort(int[] a) { for(int i=1;i<a.Length;i++){int v=a[i],j=i-1;while(j>=0&&a[j]>v){a[j+1]=a[j];j--;}a[j+1]=v;} }
}
