using Instagram.Dal;
using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Repository.Services;

public class AccauntRepository : IAccauntRepository
{
    private readonly MainContext MainContext;

    public AccauntRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> AddAccoutnAsync(Accaunt accaunt)
    {
        await MainContext.Accaunts.AddAsync(accaunt);
        await MainContext.SaveChangesAsync();
        return accaunt.AccauntId;
    }

    public async Task DeleteAccountAsync(long id)
    {
        var accountFromDb = await GetAccauntByIdAsync(id);
        MainContext.Accaunts.Remove(accountFromDb);
        await MainContext.SaveChangesAsync();
    }

    public async Task<Accaunt> GetAccauntByIdAsync(long id)
    {
        var accauntFromDb = await MainContext.Accaunts.FindAsync(id);
        return accauntFromDb == null ? throw new Exception("Accaund does not exist!") : accauntFromDb;
    }

    //public async Task<List<Accaunt>> GetAllAccountsAsync(bool includePosts = false, bool includeComments = false)
    //{
    //    // Queryable
    //    var accauntsQuery = MainContext.Accaunts.AsQueryable();
    //    if (includePosts)
    //        accauntsQuery.Include(accaunt => accaunt.Posts);
    //    if(includePosts && includeComments)
    //        accauntsQuery.Include(accaunt => accaunt.Posts).ThenInclude(post => post.Comments);

    //    // IEnumarable
    //    var accounts = await accauntsQuery.ToListAsync();
    //    return accounts;
    //}
    public async Task<List<Accaunt>> GetAllAccountsAsync(bool includePosts = false, bool includeComments = false)
    {
        var accauntsQuery = MainContext.Accaunts.AsQueryable();

        if (includePosts)
        {
            accauntsQuery = accauntsQuery.Include(accaunt => accaunt.Posts);
            if (includeComments)
                accauntsQuery = accauntsQuery.Include(accaunt => accaunt.Posts).ThenInclude(post => post.Comments);
        }

        return await accauntsQuery.ToListAsync();
    }




    public async Task UpdateAccountAsync(Accaunt accaunt)
    {
        var accountFromDb = await GetAccauntByIdAsync(accaunt.AccauntId);
        MainContext.Entry(accountFromDb).State = EntityState.Detached;
        MainContext.Accaunts.Update(accaunt);
        await MainContext.SaveChangesAsync();
    }
}
