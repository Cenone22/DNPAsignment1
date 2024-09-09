using Entities;

namespace Interfaces;

public interface IPostRepository
{
    //takes a user, and returns the created user
    Task<Post> AddAsync(Post post);
    //takes a user (with ID), and just replaces the existing User. 
    Task UpdateAsync(Post post);
    //remove the User with a given ID
    Task DeleteAsync(int id);
    //will return the User matching the given ID
    Task<Post> GetSingleAsync(int id);
    //will return an IQueryable. This is an interface which can looped over in a for-each loop to extract the relevant entities. 
    IQueryable<Post> GetMany();
}
