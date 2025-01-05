using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Shared.Models;

public class Article
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public List<string> Tags { get; set; } = [];
}