using BookStore.BorrowingService.Commands.Commands.BorrowingRequests;
using BookStore.BorrowingService.Domain.Entities;
using BookStore.BorrowingService.Domain.Interface;
using MediatR;

namespace BookStore.BorrowingService.Commands.Handlers.BorrowingRequests;

public class BorrowingRequestHandler(IBorrowingRequestRepository borrowingRequestRepository)
    : IRequestHandler<BorrowingRequestCommand, BorrowingRequest>
{
    private readonly IBorrowingRequestRepository _borrowingRequestRepository = borrowingRequestRepository;

    public Task<BorrowingRequest> Handle(BorrowingRequestCommand request, CancellationToken cancellationToken)
    {
        return _borrowingRequestRepository.CreateBorrowingRequestAsync(request.BorrowingRequest);
    }
}