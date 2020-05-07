using AngularPropertyManager.Models.DTOs.Address;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AngularPropertyManager.Models.DTOs.Property
{
    public class PropertyUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public virtual AddressDetailsDto Address { get; set; }
        public virtual List<PropertyDocument> Documents { get; set; }
        public List<IFormFile> Images { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<Tenant> Tenants { get; set; }
    }
}
