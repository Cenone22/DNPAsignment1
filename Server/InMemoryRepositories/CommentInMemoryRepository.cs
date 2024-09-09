using Entities;

namespace InMemoryRepositories;

public class CommentInMemoryRepository
{
    private readonly List<Comment> comments = new();
    
    //Adds the comment to the internal list and returns the newly added comment
    public Task<Comment> AddAsync(Comment comment)
    {
        // Generate a new ID for the comment
        comment.CommentId = comments.Count > 0 ? comments.Max(c => c.CommentId) + 1 : 1;
        comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment)
    {
        Comment? existingComment = comments.SingleOrDefault(c => c.CommentId == comment.CommentId);
        if (existingComment == null)
        {
            throw new InvalidOperationException($"Comment with ID '{comment.CommentId}' not found");
        }

        existingComment.Body = comment.Body;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Comment? commentToRemove = comments.SingleOrDefault(c => c.CommentId == id);
        if (commentToRemove == null)
        {
            throw new InvalidOperationException($"Comment with ID '{id}' not found");
        }

        comments.Remove(commentToRemove);
        return Task.CompletedTask;
    }

    public Task<Comment> GetSingleAsync(int id)
    {
        Comment? comment = comments.SingleOrDefault(c => c.CommentId == id);
        if (comment == null)
        {
            throw new InvalidOperationException($"Comment with ID '{id}' not found");
        }

        return Task.FromResult(comment);
    }

    public IQueryable<Comment> GetMany()
    {
        return comments.AsQueryable();
    }
}