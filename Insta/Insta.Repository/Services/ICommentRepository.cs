using Insta.Dal.Entities;

namespace Insta.Repository.Services;

public interface ICommentRepository
{
    Task<long> AddCommentAsync(Comment comment);
    Task<Comment> GetCommentByIdAsync(long id);
    Task<List<Comment>> GetAllComments();
}