﻿using System;

namespace NA.Domain.DomainClasses
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public AddressType AddressType { get; set; }

        public virtual Customer Customer { get; set; }

    }

    public enum AddressType
    {
        Work,
        Home
    }
}
