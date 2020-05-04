using System;
using System.Collections.Generic;

namespace AngularPropertyManager.Models
{
    public class Property : Base
    {
        public  virtual Address Address { get; set; }
        public virtual List<PropertyDocument> Documents { get; set; }
        public virtual List<Image> Images { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<Tenant> Tenants { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}