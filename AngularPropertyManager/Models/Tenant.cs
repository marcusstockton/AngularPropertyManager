using System;
using System.Collections.Generic;

namespace AngularPropertyManager.Models
{
    public class Tenant : Base
    {
        public List<Note> Notes { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string JobTitle { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Nationality { get; internal set; }
        public DateTime TenancyStartDate { get; internal set; }
    }
}