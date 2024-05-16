using BookStore.BookService.Domain.Entities;
using BookStore.BookService.Domain.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BookStore.BookService.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _collection;

    public BookRepository(IMongoClient client, IConfiguration configuration)
    {
        var databaseName = configuration.GetSection("MongoDb:DatabaseName:BookStore").Value;
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Book>(nameof(Book));
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _collection.Find(book => true).ToListAsync();
    }

    public Task<Book> GetBookByIdAsync(Guid id)
    {
        return Task.FromResult(_collection.Find(book => book.Id == id).FirstOrDefault());
    }

    public Task<Book> AddBookAsync(Book book)
    {
        _collection.InsertOne(book);
        return Task.FromResult(book);
    }
}