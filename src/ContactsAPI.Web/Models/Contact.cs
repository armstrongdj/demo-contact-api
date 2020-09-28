using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactsAPI.Web.Models
{
    public class Contact : IValidatableObject
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

        //todo: add validation regex
        public string Email { get; set; }

        [RegularExpression(@"\d\d\d\-\d\d\d-\d\d\d\d", ErrorMessage = "Invalid phone number")]
        public string CellPhone { get; set; }

        [RegularExpression(@"\d\d\d\-\d\d\d-\d\d\d\d", ErrorMessage = "Invalid phone number")]
        public string HomePhone { get; set; }

        [RegularExpression(@"\d\d\d\-\d\d\d-\d\d\d\d", ErrorMessage = "Invalid phone number")]
        public string OfficePhone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfHire { get; set; }

        public bool CurrentlyEmployed { get; set; }

        public virtual ICollection<ContactAddress> ContactAddresses { get; set; }

        public virtual ICollection<ContactRelationship> RelatedContacts { get; set; }

        public virtual ICollection<ContactRelationship> RelativeOfContacts { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(CellPhone == null && HomePhone == null && OfficePhone == null)
            {
                yield return new ValidationResult("At least one phone number is required");
            }
        }
    }
}
