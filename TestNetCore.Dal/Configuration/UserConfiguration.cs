using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Core.Model;

namespace TestNetCore.Dal.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
               .Property(m => m.Lastname)
               .IsRequired()
               .HasMaxLength(50);

            builder
            .Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(50);

            builder
            .Property(m => m.Nickname)
            .IsRequired()
            .HasMaxLength(50);

            builder
                .ToTable("User");
        }
    }
}
