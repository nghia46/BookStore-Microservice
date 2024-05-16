using BookStore.BookService.Domain.Entities;
using BookStore.BookService.Domain.Interface;
using BookStore.BookService.Queries.Queries.Books;
using MediatR;

namespace BookStore.BookService.Queries.Handlers.Books;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        return _bookRepository.GetAllBooksAsync();
    }
}