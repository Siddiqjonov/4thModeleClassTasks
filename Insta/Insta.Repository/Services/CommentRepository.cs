using Insta.Dal.Entities;
using Insta.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Insta.Repository.Services;

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

    public async Task<List<Comment>> GetAllComments()
    {
        var comments = await MainContext.Comments.ToListAsync();
        return comments;
    }

    public async Task<Comment> GetCommentByIdAsync(long id)
    {
        return await MainContext.Comments.FirstOrDefaultAsync(c => c.CommentId == id) ?? throw new NullReferenceException();
    }
}
