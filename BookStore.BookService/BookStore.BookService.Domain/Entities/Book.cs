using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.BookService.Domain.Entities;

public class Book
{
    [BsonId]
    public Guid Id { get; set; }
    [BsonElement]
    public string? Title { get; set; }
    [BsonElement]
    public string? Author { get; set; }
    [BsonElement]
    public string? Isbn { get; set; }
    [BsonElement]
    public int Quantity { get; set; }
    [BsonElement]
    public int PublishedYear { get; set; }
}