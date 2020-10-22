using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class SaltsConfiguration : IEntityTypeConfiguration<Salts>
    {
        public void Configure(EntityTypeBuilder<Salts> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .HasColumnName("UserID")
                .ValueGeneratedNever();

            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.User)
                .WithOne(p => p.Salts)
                .HasForeignKey<Salts>(d => d.UserId)
                .HasConstraintName("FK_Salts_Users");
        }
    }
}
