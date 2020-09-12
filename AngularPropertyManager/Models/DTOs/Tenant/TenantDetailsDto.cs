using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Models.DTOs.Tenant
{
    public class TenantDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public List<Note> Notes { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string JobTitle { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Nationality { get; internal set; }
        public DateTime TenancyStartDate { get; internal set; }
    }
}
