using Instagram.Dal.Entities;

namespace Instagram.Repository.Services;

public interface IAccauntRepository
{
    Task<long> AddAccoutnAsync(Accaunt accaunt);
    Task<List<Accaunt>> GetAllAccountsAsync(bool includePosts = false, bool includeComments = false);
    Task DeleteAccountAsync(long id);
    Task UpdateAccountAsync(Accaunt accaunt);
    Task<Accaunt> GetAccauntByIdAsync(long id);
}