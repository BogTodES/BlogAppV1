using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class UserPostsReactsConfig : IEntityTypeConfiguration<UserPostReacts>
    {
        public void Configure(EntityTypeBuilder<UserPostReacts> entity)
        {
            entity.HasKey(e => new { e.UserId, e.PostId, e.ReactId })
                    .HasName("PK_UserPostReacts_1");

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.Property(e => e.ReactId).HasColumnName("ReactID");

            entity.HasOne(d => d.Post)
                .WithMany(p => p.UserPostReacts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPostReacts_Posts");

            entity.HasOne(d => d.React)
                .WithMany(p => p.UserPostReacts)
                .HasForeignKey(d => d.ReactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPostReacts_ReactTypes");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserPostReacts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPostReacts_Varuti");
        }
    }
}
