using ContactsAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Web.Infrastructure
{
    public class ContactAddressEntityTypeConfiguration : IEntityTypeConfiguration<ContactAddress>
    {
        public void Configure(EntityTypeBuilder<ContactAddress> builder)
        {
            builder.HasKey(ca => new { ca.ContactId, ca.AddressId, ca.AddressType });

            builder.HasOne(ca => ca.Address)
                .WithMany(a => a.ContactAddresses)
                .HasForeignKey(ca => ca.AddressId);

            builder.HasOne(ca => ca.Contact)
                .WithMany(c => c.ContactAddresses)
                .HasForeignKey(ca => ca.ContactId);

            builder.Property(ca => ca.AddressType)
                .HasMaxLength(15);
        }
    }
}
