using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookApplication.Models
{
    public class ContactBook
    {
        public int CategoryId { get; set; }
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}