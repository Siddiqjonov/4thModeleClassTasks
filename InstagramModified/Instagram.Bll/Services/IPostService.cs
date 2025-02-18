using Instagram.Bll.DTOs;

namespace Instagram.Bll.Services;

public interface IPostService
{
    Task<long> AddAsync(PostCreateDto postCreateDto);
    Task<List<PostGetDto>> GetAllAsync(bool includeComments = false);
    Task DeleteAsync(long id);
    Task UpdateAsync(PostUpdateDto postUpdateDto);
    Task<PostGetDto> GetById(long id);
}