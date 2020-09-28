using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAPI.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset DateOfHire { get; set; }
        public bool CurrentlyEmployed { get; set; }

        public List<Address> Addresses { get; set; }
        public List<Contact> RelatedContacts { get; set; }

    }
}
