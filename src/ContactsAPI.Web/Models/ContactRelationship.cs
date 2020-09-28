using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Web.Models
{
    public class ContactRelationship
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public int RelatedContactId { get; set; }
        public Contact RelatedContact { get; set; }

        public string Relationship { get; set; }
    }
}
