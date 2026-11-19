namespace CSharpPracticum.Tasks.Level2
{
    internal class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point? p) => p is not null && X == p.X && Y == p.Y;

        public override bool Equals(object? o) => o is Point p && Equals(p);

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }

    internal class Task28_Point : ITask
    {
        public string Title => "Задание 28: Equals/GetHashCode для Point";
        public string Description => "Сравнить точки по координатам и исключить дубликаты в HashSet.";
        public string[] Requirements =>
            new[]
            {
                "Переопределить Equals(object) и GetHashCode.",
                "Реализовать IEquatable<Point>.",
                "Проверить равенство точек и HashSet.",
            };

        public void Run()
        {
            Point a = new(1, 2),
                b = new(1, 2);
            HashSet<Point> s = new() { a, b };
            Console.WriteLine($"Равны: {a.Equals(b)}; Count: {s.Count}");
        }
    }
}
