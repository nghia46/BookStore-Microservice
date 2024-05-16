using BookStore.BookService.Domain.Entities;
using BookStore.BookService.Domain.Interface;
using BookStore.BookService.Queries.Queries.Books;
using MediatR;

namespace BookStore.BookService.Queries.Handlers.Books;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return _bookRepository.GetBookByIdAsync(request.Id);
    }
}