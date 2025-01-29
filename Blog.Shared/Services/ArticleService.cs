using Blog.Shared.Data;
using Blog.Shared.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Blog.Shared.Services;
public class ArticleService {

    private readonly IMongoCollection<Article> _collection;

    public ArticleService(IOptions<MongoDbConfig> config) {
        var client = new MongoClient(config.Value.ConnectionString);
        var database = client.GetDatabase(config.Value.DatabaseName);
        _collection = database.GetCollection<Article>("Articles");
    }

    public async Task<List<Article>> GetAllArticlesAsync() {
        return await _collection.Find(article => true).ToListAsync();
    }

    public async Task CreateArticleAsync(Article article) {
        await _collection.InsertOneAsync(article);
    }
    public async Task<Article> GetArticleByIdAsync(string id) {
        return await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();
    }
    public async Task UpdateArticle(string id, Article article) {
        var filter = Builders<Article>.Filter.Eq(a => a.Id, id);
        await _collection.ReplaceOneAsync(filter, article);
    }
    public async Task DeleteArticleAsync(string id) {
        var filter = Builders<Article>.Filter.Eq(a => a.Id, id);
        await _collection.DeleteOneAsync(filter);
    }
    public Task<List<Article>> SearchArticlesByTitleAsync(string title) {
        var filter = Builders<Article>.Filter.Regex(a => a.Title, new BsonRegularExpression(title, "i"));
        return _collection.Find(filter).ToListAsync();
    }
}