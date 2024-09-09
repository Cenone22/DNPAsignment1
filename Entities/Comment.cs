namespace Entities;

public class Comment
{
    public string Body { get; set; }
    public int CommentId { get; set; }
    
    // Constructor to initialize all properties
    public Comment(int commentId, string body)
    {
        CommentId = commentId;
        Body = body;
    }
    
    // Constructor to initialize with dummy data
    public Comment()
    {
        CommentId = 1;
        Body = "The dummy comment.";
    }
}