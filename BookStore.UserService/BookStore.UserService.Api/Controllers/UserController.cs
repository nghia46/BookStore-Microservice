using BookStore.UserService.Commands.Commands.Users;
using BookStore.UserService.Domain.Entities;
using BookStore.UserService.Queries.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.UserService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var result = await _sender.Send(new GetUsersQuery());
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> AddUserAsync(AddUserCommand addUserCommand)
    {
        var result = await _sender.Send(addUserCommand);
        return Ok(result);
    }
}