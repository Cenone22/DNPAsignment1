using Entities;

namespace Interfaces;

public interface IUserRepository
{
// Takes a user, and returns the created user
    Task<User> AddAsync(User user);
    // Takes a user (with ID), and just replaces the existing user
    Task UpdateAsync(User user);
    // Removes the user with a given ID
    Task DeleteAsync(int id);
    // Returns the user matching the given ID
    Task<User> GetSingleAsync(int id);
    // Returns an IQueryable for multiple users (not sure whether it will be useful later)
    IQueryable<User> GetMany();
}