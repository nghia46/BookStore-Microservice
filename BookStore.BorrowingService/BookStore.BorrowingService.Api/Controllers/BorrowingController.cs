using BookStore.BorrowingService.Commands.Commands.BorrowingRequests;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BorrowingService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowingController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBorrowingRequestAsync(BorrowingRequestCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }
}