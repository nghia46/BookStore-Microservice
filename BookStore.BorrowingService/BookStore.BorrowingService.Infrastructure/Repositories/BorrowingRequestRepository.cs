using BookStore.BorrowingService.Domain.Interface;
using BookStore.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BookStore.BorrowingService.Infrastructure.Repositories;

public class BorrowingRequestRepository : IBorrowingRequestRepository
{
    private readonly IMongoCollection<BorrowingRequest> _collection;

    public BorrowingRequestRepository(IMongoClient client, IConfiguration configuration)
    {
        var databaseName = configuration.GetSection("MongoDb:DatabaseName:BookStore").Value;
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<BorrowingRequest>(nameof(BorrowingRequest));
    }

    public Task<BorrowingRequest> CreateBorrowingRequestAsync(BorrowingRequest borrowingRequest)
    {
        BorrowingRequest request = new()
        {
            Id = Guid.NewGuid(),
            UserId = borrowingRequest.UserId,
            BookId = borrowingRequest.BookId,
            BorrowedDate = borrowingRequest.BorrowedDate,
            Status = BorrowingStatus.Pending,
            CreatedAt = DateTime.Now
        };
        return _collection.InsertOneAsync(request).ContinueWith(_ => request);
    }
}