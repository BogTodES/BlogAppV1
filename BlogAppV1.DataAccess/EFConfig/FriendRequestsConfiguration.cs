using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess.EFConfig
{
    class FriendRequestsConfiguration : IEntityTypeConfiguration<FriendRequests>
    {
        public void Configure(EntityTypeBuilder<FriendRequests> entity)
        {
            entity.HasKey(e => new { e.SenderId, e.ReceiverId });

            entity.Property(e => e.CreateDate).HasColumnType("date");

            entity.HasOne(d => d.Receiver)
                .WithMany(p => p.FriendRequestsReceiver)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FriendRequests_Users1");

            entity.HasOne(d => d.Sender)
                .WithMany(p => p.FriendRequestsSender)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FriendRequests_Users");
        }
    }
}
