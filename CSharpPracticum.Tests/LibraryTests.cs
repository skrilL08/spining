using CSharpPracticum.Tasks.Level3;
using Xunit;

namespace CSharpPracticum.Tests;

public class LibraryTests
{
    [Fact]
    public void BorrowMakesBookUnavailable()
    {
        var book = new Book("Книга", "Автор"); var reader = new Reader("Аня");
        new Library().Borrow(book, reader);
        Assert.False(book.IsAvailable); Assert.Contains(book, reader.BorrowedBooks);
    }

    [Fact]
    public void ReturnMakesBookAvailable()
    {
        var book = new Book("Книга", "Автор"); var reader = new Reader("Аня"); var library = new Library();
        library.Borrow(book, reader); library.Return(book, reader);
        Assert.True(book.IsAvailable); Assert.Empty(reader.BorrowedBooks);
    }

    [Fact]
    public void CannotBorrowBookTwice()
    {
        var book = new Book("Книга", "Автор"); var library = new Library(); library.Borrow(book, new Reader("Аня"));
        Assert.Throws<InvalidOperationException>(() => library.Borrow(book, new Reader("Борис")));
    }

    [Fact]
    public void ReaderCannotBorrowMoreThanThreeBooks()
    {
        var library = new Library(); var reader = new Reader("Аня");
        for (int i = 1; i <= 3; i++) library.Borrow(new Book($"Книга {i}", "Автор"), reader);
        Assert.Throws<InvalidOperationException>(() => library.Borrow(new Book("Четвёртая", "Автор"), reader));
    }

    [Fact]
    public void CannotReturnBookReaderDoesNotHave()
    {
        var library = new Library(); var reader = new Reader("Аня"); var book = new Book("Книга", "Автор");
        Assert.Throws<InvalidOperationException>(() => library.Return(book, reader));
    }
}
