using FluentValidation;
using Instagram.Bll.DTOs;
using Instagram.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.Validators;

public class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
{
    private readonly IAccauntRepository AccauntRepository;

    public PostCreateDtoValidator(IAccauntRepository accauntRepository)
    {
        AccauntRepository = accauntRepository;
        RuleFor(p => p.PostType)
            .MaximumLength(10).WithMessage("Post type must be within 10 chars");
        RuleFor(p => p.AccauntId)
            .NotEmpty()
            .MustAsync(AccauntExists)
            .WithMessage("Accaund does not exist!");
    }
    private async Task<bool> AccauntExists(long id, CancellationToken token)
    {
        return await AccauntRepository.GetAccauntByIdAsync(id) == null ? false : true;
    }
}
