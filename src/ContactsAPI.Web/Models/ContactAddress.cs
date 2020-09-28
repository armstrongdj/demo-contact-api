using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Web.Models
{
    public class ContactAddress
    {
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public string AddressType { get; set; }
    }
}
