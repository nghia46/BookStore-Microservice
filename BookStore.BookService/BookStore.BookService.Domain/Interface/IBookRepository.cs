using BookStore.BookService.Domain.Entities;

namespace BookStore.BookService.Domain.Interface;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(Guid id);
    Task<Book> AddBookAsync(Book book);
}