using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    public class BlogsConfiguration : IEntityTypeConfiguration<Blogs>
    {
        public void Configure(EntityTypeBuilder<Blogs> entity)
        {
            entity.HasIndex(e => e.Id)
                    .HasName("IX_Blogs")
                    .IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'Enter a title')");

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Photo)
                .WithMany(p => p.Blogs)
                .HasForeignKey(d => d.PhotoId)
                .HasConstraintName("FK_Blogs_Media");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blogs_Users");
        }
    }
}
