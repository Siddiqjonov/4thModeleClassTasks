using Instagram.Dal;
using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Repository.Services;

public class CommentRepository : ICommentRepository
{
    private readonly MainContext MainContext;

    public CommentRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> AddCommentAsync(Comment comment)
    {
        await MainContext.Comments.AddAsync(comment);
        await MainContext.SaveChangesAsync();
        return comment.CommentId;
    }

    public async Task<bool> CommentExistsAsync(long id)
    {
        var res = await MainContext.Comments.AnyAsync(c => c.CommentId == id);
        return res;
    }

    public async Task DeleteCommentAsync(long id)
    {
        var commentFromDb = await GetCommentByIdAsync(id);
        MainContext.Comments.Remove(commentFromDb);
        await MainContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        var comments = await MainContext.Comments.ToListAsync();
        return comments;
    }

    public async Task<Comment> GetCommentByIdAsync(long id)
    {
        var commentFromDb = await MainContext.Comments.FindAsync(id);
        if(commentFromDb == null) throw new NullReferenceException();
        return commentFromDb;
    }

    public async Task UpdateCommentAsync(Comment comment)
    {
        var commentFromDb = await GetCommentByIdAsync(comment.CommentId);
        commentFromDb.Body = comment.Body;
        commentFromDb.CreatedTime = comment.CreatedTime;
        await MainContext.SaveChangesAsync(); 
    }
}
