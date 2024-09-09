using Entities;
using Interfaces;

namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private readonly List<User> users = new();

    public Task<User> AddAsync(User user)
    {
        // Generating a new ID for the user
        user.UserId = users.Count > 0 ? users.Max(u => u.UserId) + 1 : 1;
        users.Add(user);
        return Task.FromResult(user);
    }
    // Not sure if Update and Delete would be necessary, but in case User data wants to be updated or User to be deleted
    public Task UpdateAsync(User user)
    {
        User? existingUser = users.SingleOrDefault(u => u.UserId == user.UserId);
        if (existingUser == null)
        {
            throw new InvalidOperationException($"User ID '{user.UserId}' not found");
        }

        existingUser.UserName = user.UserName;
        existingUser.Password = user.Password;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        User? userToRemove = users.SingleOrDefault(u => u.UserId == id);
        if (userToRemove == null)
        {
            throw new InvalidOperationException($"User ID '{id}' not found");
        }

        users.Remove(userToRemove);
        return Task.CompletedTask;
    }

    public Task<User> GetSingleAsync(int id)
    {
        User? user = users.SingleOrDefault(u => u.UserId == id);
        if (user == null)
        {
            throw new InvalidOperationException($"User ID '{id}' not found");
        }

        return Task.FromResult(user);
    }

    //
    public IQueryable<User> GetMany()
    {
        return users.AsQueryable();
    }
}