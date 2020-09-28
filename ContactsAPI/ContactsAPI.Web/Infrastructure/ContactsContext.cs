using ContactsAPI.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAPI.Web.Infrastructure
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) :
            base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
