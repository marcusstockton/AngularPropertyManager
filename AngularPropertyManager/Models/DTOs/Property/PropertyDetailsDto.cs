using AngularPropertyManager.Models.DTOs.Address;
using AngularPropertyManager.Models.DTOs.Portfolio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AngularPropertyManager.Models.DTOs.Tenant;

namespace AngularPropertyManager.Models.DTOs.Property
{
    public class PropertyDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public virtual AddressDetailsDto Address { get; set; }
        public virtual List<PropertyDocument> Documents { get; set; }
        public virtual List<Image> Images { get; set; }
        public double PurchasePrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime PurchaseDate { get; set; }
        public List<TenantDetailsDto> Tenants { get; set; }
        public virtual PortfolioDetailsDto Portfolio { get; set; }
    }
}
