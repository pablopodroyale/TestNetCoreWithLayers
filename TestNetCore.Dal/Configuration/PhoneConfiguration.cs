using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Core.Model;

namespace TestNetCore.Dal.Configuration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                 .Property(m => m.Number)
                .IsRequired();

            builder
               .HasOne(m => m.Users)
               .WithMany(a => a.Phones);
            builder
              .ToTable("Phone");
        }
    }
}
