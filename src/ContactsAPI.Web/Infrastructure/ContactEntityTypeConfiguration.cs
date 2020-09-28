using ContactsAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Web.Infrastructure
{
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.EmployeeId)
                .HasMaxLength(10);

            builder.Property(c => c.Email)
                .HasMaxLength(100);

            builder.Property(c => c.CellPhone)
                .HasMaxLength(25);

            builder.Property(c => c.HomePhone)
                .HasMaxLength(25);

            builder.Property(c => c.OfficePhone)
                .HasMaxLength(25);
            

            //support lookup by last name
            builder.HasIndex(c => c.LastName);
        }
    }
}
