using BookStore.BookService.Domain.Entities;
using MediatR;

namespace BookStore.BookService.Queries.Queries.Books;

public record GetBooksQuery() : IRequest<IEnumerable<Book>>;