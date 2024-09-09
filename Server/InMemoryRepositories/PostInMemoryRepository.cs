using Entities;
using Interfaces;

namespace InMemoryRepositories;

public class PostInMemoryRepository : IPostRepository
{
    private List<Post> posts;
    
    private IPostRepository _postRepositoryImplementation;
    //takes a Post as parameter, returns a Post (inside a Task)
    public Task<Post> AddAsync(Post post)
    {
        post.Id = posts.Any() 
            ? posts.Max(p => p.Id) + 1
            : 1;
        posts.Add(post);
        return Task.FromResult(post);
    }
    
    //It receives a post, and returns nothing, i.e. a Task not containing an object
    public Task UpdateAsync(Post post)
    {
        //the question mark indicates the variable ”existingPost” may be null
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id);
        if (existingPost is null)
        {
            throw new InvalidOperationException(
                $"Post with ID '{post.Id}' not found");
        }

        posts.Remove(existingPost);
        posts.Add(post);

        return Task.CompletedTask;
    }
    
    public Task DeleteAsync(int id)
    {
        Post? postToRemove = posts.SingleOrDefault(p => p.Id == id);
        if (postToRemove is null)
        {
            throw new InvalidOperationException(
                $"Post with ID '{id}' not found");
        }

        posts.Remove(postToRemove);
        return Task.CompletedTask;
    }
    
    public Task<Post> GetSingleAsync(int id)
    {
        // Attempt to find the post by its ID
        Post? post = posts.SingleOrDefault(p => p.Id == id);
    
        // If the post is not found, throw an exception
        if (post is null)
        {
            throw new InvalidOperationException(
                $"Post with ID '{id}' not found");
        }

        // Return the found post wrapped in a Task
        return Task.FromResult(post);
    }

    // This is an interface, which just provides the option to loop through it, e.g. with a for-each loop
    // In the given example it was "GetManyAsync()" ??
    public IQueryable<Post> GetMany()
    {
        return posts.AsQueryable();
    }
}