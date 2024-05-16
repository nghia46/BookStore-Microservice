using BookStore.BookService.Domain.Entities;
using MediatR;

namespace BookStore.BookService.Queries.Queries.Books;

public record GetBookByIdQuery(Guid Id) : IRequest<Book>;
