using Blog.Shared.Data;
using MongoDB.Driver;
using Blog.Shared.Models;
using Microsoft.Extensions.Options;


namespace Blog.Shared.Services;
public class ArticleService {
    
    private readonly IMongoCollection<Article> _collection;

    public ArticleService(IOptions<MongoDbConfig> config) {
        var client =  new MongoClient(config.Value.ConnectionString);
        var database = client.GetDatabase(config.Value.DatabaseName);
        _collection = database.GetCollection<Article>("Articles");
    }

    public async Task<List<Article>> GetAllArticlesAsync() {
        return await _collection.Find(article => true).ToListAsync();
    }
    
    
}