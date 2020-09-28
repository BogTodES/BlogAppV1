using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class BlogsSectionsConfiguration : IEntityTypeConfiguration<BlogsSections>
    {
        public void Configure(EntityTypeBuilder<BlogsSections> entity)
        {
            entity.HasKey(e => new { e.BlogId, e.SectionId });

            entity.Property(e => e.BlogId).HasColumnName("BlogID");

            entity.Property(e => e.SectionId).HasColumnName("SectionID");

            entity.HasOne(d => d.Blog)
                .WithMany(p => p.BlogsSections)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogsSections_Sections");

            entity.HasOne(d => d.Section)
                .WithMany(p => p.BlogsSections)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogsSections_Sections1");
        }
    }
}
