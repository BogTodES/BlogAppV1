using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class PostsConfiguration : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Body)
                .IsRequired()
                .HasDefaultValueSql("('Text')");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

            entity.Property(e => e.SectionId).HasColumnName("SectionID");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'Temp')");

            entity.HasOne(d => d.Photo)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.PhotoId)
                .HasConstraintName("FK_Posts_Media");

            entity.HasOne(d => d.Section)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Posts_Sections");
        }
    }
}
