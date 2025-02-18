using FluentValidation;
using Instagram.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.Validators;

public class AccauntCreateDtoValidator : AbstractValidator<AccauntCreateDto>
{
    public AccauntCreateDtoValidator()
    {
        RuleFor(account => account.UserName)
            .MaximumLength(30).NotEmpty()
            .WithMessage("UserName is empty or has more than 30 characters");
        RuleFor(account => account.Bio).MaximumLength(200).WithMessage("Bio must be within 200 chars");
    }
}
