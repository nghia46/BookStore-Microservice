using BookStore.BookService.Domain.Entities;
using MediatR;

namespace BookStore.BookService.Commands.Commands.Books;

public record AddBookCommand(Book Book) : IRequest<Book>;
