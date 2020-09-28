using ContactsAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Web.Infrastructure
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(c => c.Line1)
                .HasMaxLength(100);

            builder.Property(c => c.Line2)
                .HasMaxLength(100);

            builder.Property(c => c.City)
                .HasMaxLength(50);

            builder.Property(c => c.State)
                .HasMaxLength(2);

            builder.Property(c => c.ZipCode)
                .HasMaxLength(10);
        }
    }
}
