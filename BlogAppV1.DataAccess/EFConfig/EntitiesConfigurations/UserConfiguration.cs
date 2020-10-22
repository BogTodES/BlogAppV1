using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> entity)
        {
            entity.HasIndex(e => e.Email)
                    .HasName("IX_Users_1")
                    .IsUnique();

            entity.HasIndex(e => e.Username)
                .HasName("IX_Users")
                .IsUnique();

            entity.Property(e => e.Birthdate).HasColumnType("date");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Gender).HasDefaultValueSql("((0))");

            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Photo)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.PhotoId)
                .HasConstraintName("FK_Users_Media");
        }
    }
}
