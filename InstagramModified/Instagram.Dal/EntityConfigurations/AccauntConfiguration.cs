using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Dal.EntityConfigurations;

public class AccauntConfiguration : IEntityTypeConfiguration<Accaunt>
{
    public void Configure(EntityTypeBuilder<Accaunt> builder)
    {
        builder.ToTable("Accaunt");

        builder.HasKey(a => a.AccauntId);

        builder.Property(a => a.UserName)
            .IsRequired(true)
            .HasMaxLength(30);
        builder.HasIndex(a => a.UserName).IsUnique(true);

        builder.Property(a => a.Bio)
            .IsRequired(false)
            .HasMaxLength(200);


        builder.HasMany(a => a.Posts)
            .WithOne(p => p.Accaunt)
            .HasForeignKey(p => p.AccauntId)
            .OnDelete(DeleteBehavior.Restrict); ;

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Accaunt)
            .HasForeignKey(c => c.AccauntId)
            .OnDelete(DeleteBehavior.Restrict); ;
    }
}
