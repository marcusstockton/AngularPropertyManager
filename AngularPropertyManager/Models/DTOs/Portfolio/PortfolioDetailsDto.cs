using AngularPropertyManager.Models.DTOs.ApplicationUser;
using AngularPropertyManager.Models.DTOs.Property;
using System;
using System.Collections.Generic;

namespace AngularPropertyManager.Models.DTOs.Portfolio
{
    public class PortfolioDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string Name { get; set; }
        public ApplicationUserDetailsDto Owner { get; set; }
        public virtual List<PropertyDetailsDto> Properties { get; set; }
    }
}
