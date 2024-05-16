using BookStore.BorrowingService.Commands.Commands.BorrowingRequests;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BorrowingService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowingController(ISender sender, ISendEndpointProvider provider) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBorrowingRequestAsync(BorrowingRequestCommand command)
    {
        var result = await sender.Send(command);
        var endpoint = await provider.GetSendEndpoint(new Uri("queue:borrowing-queue"));
        await endpoint.Send(result);
        return Ok(result);
    }
}