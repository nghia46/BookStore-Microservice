using BookStore.BookService.Commands.Commands.Books;
using BookStore.BookService.Queries.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BookService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ISender _sender;

    public BookController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var result = await _sender.Send(new GetBooksQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var result = await _sender.Send(new GetBookByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] AddBookCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
}