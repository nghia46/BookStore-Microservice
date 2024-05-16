using BookStore.BookService.Commands.Commands.Books;
using BookStore.BookService.Domain.Entities;
using BookStore.BookService.Domain.Interface;
using MediatR;

namespace BookStore.BookService.Commands.Handlers.Books;

public class AddBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<AddBookCommand, Book>
{
    public Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        Book book = new()
        {
            Id = Guid.NewGuid(),
            Title = request.Book.Title,
            Author = request.Book.Author,
            Isbn = request.Book.Isbn,
            Quantity = request.Book.Quantity,
            PublishedYear = request.Book.PublishedYear
        };
        return bookRepository.AddBookAsync(book);
    }
}