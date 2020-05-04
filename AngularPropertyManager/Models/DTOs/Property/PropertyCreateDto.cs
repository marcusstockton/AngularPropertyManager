using AngularPropertyManager.Models.DTOs.Address;
using System;

namespace AngularPropertyManager.Models.DTOs.Property
{
    public class PropertyCreateDto
    {
        public AddressCreateDto Address { get; set; }
        //public virtual List<PropertyDocument> Documents { get; set; }
        //public virtual List<Image> Images { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        //public virtual List<Tenant> Tenants { get; set; }
    }
}
