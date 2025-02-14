using Insta.Bll.Dtos;

namespace Insta.Bll.Services;

public interface ICommentService
{
    Task<long> AddAsync(CommentCreateDto commentCreateDto);
    Task<CommentGetDto> GetByIdAsync(long id);
    Task<List<CommentGetDto>> GetAllAsync();
}