using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.UserService.Domain.Entities;

public class User
{
    [BsonId]
    public Guid Id { get; set; }
    [BsonElement]
    public string? Name { get; set; }
    [BsonElement]
    public string? Email { get; set; }
    [BsonElement]
    public string? Password { get; set; }
    [BsonElement]
    public string? Role { get; set; }
    [BsonElement]
    public DateTime CreatedAt { get; set; }
    [BsonElement]
    public DateTime UpdatedAt { get; set; }
}