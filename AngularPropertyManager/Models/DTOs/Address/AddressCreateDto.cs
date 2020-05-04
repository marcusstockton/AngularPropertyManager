using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Models.DTOs.Address
{
    public class AddressCreateDto
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}
