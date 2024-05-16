using BookStore.UserService.Domain.Entities;
using BookStore.UserService.Domain.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BookStore.UserService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _userCollection;

    public UserRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        var databaseName = configuration.GetSection("MongoDb:DatabaseName:BookStore").Value;
        var database = mongoClient.GetDatabase(databaseName);
        _userCollection = database.GetCollection<User>(nameof(User));
    }
    
    public Task<User> AddUserAsync(User user)
    {
        return _userCollection.InsertOneAsync(user).ContinueWith(t => user);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
}