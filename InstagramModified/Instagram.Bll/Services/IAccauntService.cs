using Instagram.Bll.DTOs;
using Instagram.Dal.Entities;

namespace Instagram.Bll.Services;

public interface IAccauntService
{
    Task<long> AddAsync(AccauntCreateDto accauntCreateDto);
    Task<List<AccauntGetDto>> GetAllAsync(bool includePosts = false, bool includeComments = false);
    Task UpdateAsync(AccauntUpdateDto accauntUpdateDto);
    Task DeleteAsync(long id);
    Task<AccauntGetDto> GetByIdAsync(long id);
}