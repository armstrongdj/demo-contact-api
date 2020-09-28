using ContactsAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Web.Infrastructure
{
    public class ContactRelationshipEntityTypeConfiguration : IEntityTypeConfiguration<ContactRelationship>
    {
        public void Configure(EntityTypeBuilder<ContactRelationship> builder)
        {
            builder.HasKey(cr => new { cr.ContactId, cr.RelatedContactId });

            builder.HasOne(cr => cr.Contact)
                .WithMany(c => c.RelatedContacts)
                .HasForeignKey(cr => cr.ContactId);

            builder.HasOne(cr => cr.RelatedContact)
                .WithMany(c => c.RelativeOfContacts)
                .HasForeignKey(cr => cr.RelatedContactId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(cr => cr.Relationship)
                .HasMaxLength(20);
        }
    }
}
