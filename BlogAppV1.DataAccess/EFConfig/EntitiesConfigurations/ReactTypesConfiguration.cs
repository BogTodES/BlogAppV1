using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class ReactTypesConfiguration : IEntityTypeConfiguration<ReactTypes>
    {
        public void Configure(EntityTypeBuilder<ReactTypes> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
