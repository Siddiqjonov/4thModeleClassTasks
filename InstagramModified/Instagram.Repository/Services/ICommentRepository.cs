using Instagram.Dal.Entities;

namespace Instagram.Repository.Services;

public interface ICommentRepository
{
    Task<long> AddCommentAsync(Comment comment);
    Task<Comment> GetCommentByIdAsync(long id);
    Task<List<Comment>> GetAllCommentsAsync();
    Task DeleteCommentAsync(long id);
    Task UpdateCommentAsync(Comment comment);
    Task<bool> CommentExistsAsync(long id);
}