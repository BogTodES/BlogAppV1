using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Body).IsRequired();

            entity.Property(e => e.Date).HasColumnType("date");

            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Posts");
        }
    }
}
