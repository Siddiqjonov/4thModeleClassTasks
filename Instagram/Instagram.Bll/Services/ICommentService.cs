using Instagram.Bll.DTOs;

namespace Instagram.Bll.Services;

public interface ICommentService
{
    Task<long> AddAsync(CommentCreateDto commentCreateDto);
    Task<CommentGetDto> GetByIdAsync(long id);
    Task<List<CommentGetDto>> GetAllAsync();
    Task DeleteAsync(long id);
    Task UpdateAsync(UpdateCommentDto updateCommentDto);
}