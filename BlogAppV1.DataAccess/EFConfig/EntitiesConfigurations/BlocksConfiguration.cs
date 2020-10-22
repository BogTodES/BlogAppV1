using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    public class BlocksConfiguration : IEntityTypeConfiguration<Blocks>
    {
        public void Configure(EntityTypeBuilder<Blocks> entity)
        {
            entity.HasKey(e => new { e.SenderId, e.BlockedId });

            entity.HasOne(d => d.Blocked)
                .WithMany(p => p.BlocksBlocked)
                .HasForeignKey(d => d.BlockedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blocks_Users1");

            entity.HasOne(d => d.Sender)
                .WithMany(p => p.BlocksSender)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blocks_Users");
        }
    }
}
