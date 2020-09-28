using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class SectionsConfiguration : IEntityTypeConfiguration<Sections>
    {
        public void Configure(EntityTypeBuilder<Sections> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

            entity.HasOne(d => d.Photo)
                .WithMany(p => p.Sections)
                .HasForeignKey(d => d.PhotoId)
                .HasConstraintName("FK_Sections_Media");
        }
    }
}
