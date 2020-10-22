using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class UserCommentReactsConfig : IEntityTypeConfiguration<UserCommentReacts>
    {
        public void Configure(EntityTypeBuilder<UserCommentReacts> entity)
        {
            entity.HasKey(e => new { e.UserId, e.CommentId, e.ReactId });

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");

            entity.Property(e => e.ReactId).HasColumnName("ReactID");

            entity.HasOne(d => d.Comment)
                .WithMany(p => p.UserCommentReacts)
                .HasForeignKey(d => d.CommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCommentReacts_Comments");

            entity.HasOne(d => d.React)
                .WithMany(p => p.UserCommentReacts)
                .HasForeignKey(d => d.ReactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCommentReacts_ReactTypes");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserCommentReacts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCommentReacts_Varuti");
        }
    }
}
