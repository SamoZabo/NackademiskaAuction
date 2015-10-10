using System;
using System.Collections.Generic;

namespace NA.Domain.DomainClasses
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
