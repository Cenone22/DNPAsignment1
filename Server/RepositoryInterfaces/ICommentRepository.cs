﻿using Entities;

namespace Interfaces;

public interface ICommentRepository
{
    Task<Comment> AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(int id);
    Task<Comment> GetSingleAsync(int id);
    IQueryable<Post> GetMany();
}