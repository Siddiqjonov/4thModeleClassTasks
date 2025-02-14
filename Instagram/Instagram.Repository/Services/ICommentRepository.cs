using Instagram.Dal.Entities;

namespace Instagram.Repository.Services;

public interface ICommentRepository
{
    Task<long> AddCommentAsync(Comment comment);
    Task<Comment> GetCommentByIdAsync(long id);
    Task<List<Comment>> GetAllComments();
}