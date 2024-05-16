using BookStore.BorrowingService.Domain.Entities;

namespace BookStore.BorrowingService.Domain.Interface;

public interface IBorrowingRequestRepository
{
    Task<BorrowingRequest> CreateBorrowingRequestAsync(BorrowingRequest borrowingRequest);
}