using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Dal.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");

        builder.HasKey(c => c.CommentId);

        builder.Property(c => c.Body)
            .IsRequired(true)
            .HasMaxLength(200);

        builder.Property(c => c.CreatedTime)
            .IsRequired(true);

        // first option
        builder.HasOne(c => c.ParentComment)
            .WithMany(pC => pC.Replies)
            .HasForeignKey(pC => pC.ParentCommentId).
            OnDelete(DeleteBehavior.NoAction);

        //// second option
        //builder.HasMany(c => c.Replies)
        //    .WithOne(pC => pC.ParentComment)
        //    .HasForeignKey(pC => pC.ParentCommentId);
    }
}
