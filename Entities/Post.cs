namespace Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
    
    // Constructor to initialize all properties
    public Post(int id, string title, string body, int userId)
    {
        Id = id;
        Title = title;
        Body = body;
        UserId = userId;
    }
    
    public Post()
    {
        Id = 1;
        Title = "Dummy post Title";
        Body = "The body of the dummy post.";
        UserId = 1;
    }
}