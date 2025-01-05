namespace Blog.Shared;

public class Article
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public List<string> Tags { get; set; } = [];
}