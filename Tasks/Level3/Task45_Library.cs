namespace CSharpPracticum.Tasks.Level3
{
    internal class Book { public string Title { get; } public string Author { get; } public bool IsAvailable { get; set; } = true; public Book(string title, string author) { Title = title; Author = author; } }
    internal class Reader { public string Name { get; } public List<Book> BorrowedBooks { get; } = new(); public Reader(string name) { Name = name; } }
    internal class Library
    {
        public void Borrow(Book book, Reader reader) { if (!book.IsAvailable) throw new InvalidOperationException("Книгу уже выдали."); if (reader.BorrowedBooks.Count >= 3) throw new InvalidOperationException("Читатель уже взял три книги."); book.IsAvailable = false; reader.BorrowedBooks.Add(book); }
        public void Return(Book book, Reader reader) { if (!reader.BorrowedBooks.Remove(book)) throw new InvalidOperationException("У читателя нет этой книги."); book.IsAvailable = true; }
    }
    internal class Task45_Library : ITask
    {
        public string Title => "Задание 45: Библиотека";
        public string Description => "Выдавать и принимать книги с ограничением в три книги на читателя.";
        public string[] Requirements => new[] { "Реализовать Book, Reader и Library.", "Проверить выдачу, возврат, лимит и ошибки." };
        public void Run()
        {
            var library = new Library(); var reader = new Reader("Аня"); var books = Enumerable.Range(1, 4).Select(i => new Book($"Книга {i}", "Автор")).ToList(); int passed = 0;
            library.Borrow(books[0], reader); if (!books[0].IsAvailable && reader.BorrowedBooks.Count == 1) passed++;
            library.Return(books[0], reader); if (books[0].IsAvailable && reader.BorrowedBooks.Count == 0) passed++;
            library.Borrow(books[0], reader); try { library.Borrow(books[0], reader); } catch (InvalidOperationException) { passed++; }
            library.Borrow(books[1], reader); library.Borrow(books[2], reader); try { library.Borrow(books[3], reader); } catch (InvalidOperationException) { passed++; }
            try { library.Return(books[3], reader); } catch (InvalidOperationException) { passed++; }
            Console.WriteLine($"Проверки сценариев: {passed}/5 пройдены.");
            Console.WriteLine("ТЗ просит xUnit/NUnit-тесты; тестовый проект будет добавлен отдельно.");
        }
    }
}
