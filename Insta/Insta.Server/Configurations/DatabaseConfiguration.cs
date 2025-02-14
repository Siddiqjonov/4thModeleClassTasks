using Insta.Dal;
using Microsoft.EntityFrameworkCore;

namespace Insta.Server.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionString));
    }
}
