using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace NA.Domain.DomainClasses
{
    public class Customer : IPrincipal
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public IList<Address> Addresses { get; set; }

        public IIdentity Identity
        {
            get { return new GenericIdentity(this.Email);}
        }

        public bool IsInRole(string role)
        {
            return this.Role.ToString() == role;
        }
    }

    public enum Role
    {
        Admin,
        Customer
    }
}
