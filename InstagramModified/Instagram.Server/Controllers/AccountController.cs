using Instagram.Bll.DTOs;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccauntService AccauntService;

    public AccountController(IAccauntService accauntService)
    {
        AccauntService = accauntService;
    }

    [HttpPost("add")]
    public async Task<long> AddAccount(AccauntCreateDto accauntCreateDto)
    {
        var id = await AccauntService.AddAsync(accauntCreateDto);
        return id;
    }
    
    [HttpGet("getAll")]
    public async Task<List<AccauntGetDto>> GetAllAccount(bool includePosts, bool includeComments)
    {
        var accounts = await AccauntService.GetAllAsync(includePosts, includeComments);
        return accounts;
    }
    
    [HttpDelete("delete")]
    public async Task DeleteAsync(long id)
    {
        await AccauntService.DeleteAsync(id);
    }
    
    [HttpPut("update")]
    public async Task UpdateAsync(AccauntUpdateDto accauntUpdateDto)
    {
        await AccauntService.UpdateAsync(accauntUpdateDto);
    }
    
    [HttpGet("getById")]
    public async Task<AccauntGetDto> GetAccountById(long id)
    {
        var account = await AccauntService.GetByIdAsync(id);
        return account;
    }
}
