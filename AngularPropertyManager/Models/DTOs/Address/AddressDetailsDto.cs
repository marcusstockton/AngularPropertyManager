﻿using System;

namespace AngularPropertyManager.Models.DTOs.Address
{
    public class AddressDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}
