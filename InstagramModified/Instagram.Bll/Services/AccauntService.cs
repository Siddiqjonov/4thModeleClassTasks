using AutoMapper;
using FluentValidation;
using Instagram.Bll.DTOs;
using Instagram.Dal.Entities;
using Instagram.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.Services;

public class AccauntService : IAccauntService
{
    private readonly IAccauntRepository AccauntRepository;
    private readonly IValidator<AccauntCreateDto> AccauntCreateDtoValidatorc;
    private readonly IMapper Mapper;

    public AccauntService(IAccauntRepository accauntRepository,
        IValidator<AccauntCreateDto> accauntCreateDtoValidatorc,
        IMapper mapper)
    {
        AccauntRepository = accauntRepository;
        AccauntCreateDtoValidatorc = accauntCreateDtoValidatorc;
        Mapper = mapper;
    }

    public async Task<long> AddAsync(AccauntCreateDto accauntCreateDto)
    {
        var accaunt = Mapper.Map<Accaunt>(accauntCreateDto);
        var id = await AccauntRepository.AddAccoutnAsync(accaunt);
        return id;
    }

    public async Task DeleteAsync(long id)
    {
        await AccauntRepository.DeleteAccountAsync(id);
    }

    public async Task<List<AccauntGetDto>> GetAllAsync(bool includePosts = false, bool includeComments = false)
    {
        var accounts = await AccauntRepository.GetAllAccountsAsync(includePosts, includeComments);
        var accountGetDtos = accounts.Select(account => Mapper.Map<AccauntGetDto>(account)).ToList();
        return accountGetDtos;
    }


    public async Task<AccauntGetDto> GetByIdAsync(long id)
    {
        var account = await AccauntRepository.GetAccauntByIdAsync(id);
        var accountGetDto = Mapper.Map<AccauntGetDto>(account);
        return accountGetDto;
    }

    public async Task UpdateAsync(AccauntUpdateDto accauntUpdateDto)
    {
        var account = Mapper.Map<Accaunt>(accauntUpdateDto);
        await AccauntRepository.UpdateAccountAsync(account);
    }
}
