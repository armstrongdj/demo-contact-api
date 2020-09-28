using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAPI.Web.Models
{
    public class Contact
    {
        public Contact()
        {
            ContactAddresses = new List<ContactAddress>();
            RelatedContacts = new List<ContactRelationship>();
            RelativeOfContacts = new List<ContactRelationship>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfHire { get; set; }
        public bool CurrentlyEmployed { get; set; }

        public virtual ICollection<ContactAddress> ContactAddresses { get; set; }
        public virtual ICollection<ContactRelationship> RelatedContacts { get; set; }
        public virtual ICollection<ContactRelationship> RelativeOfContacts { get; set; }

    }
}
