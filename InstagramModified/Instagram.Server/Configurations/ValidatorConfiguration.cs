using FluentValidation;
using Instagram.Bll.DTOs;
using Instagram.Dal;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Server.Configurations;

public static class ValidatorConfiguration
{
    public static void ConfigureValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<CommentCreateDto>();
    }
}
