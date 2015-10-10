using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NA.DataLayer.DbContext;
using NA.Domain.Repository;

namespace NA.Web.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IEFContext _db;

        public AddressRepository(IEFContext db)
        {
            _db = db;
        }
        public Domain.DomainClasses.Address Get(Guid addressId)
        {
            return _db.Addresses.FirstOrDefault(a => a.Id == addressId);
        }

        public IList<Domain.DomainClasses.Address> GetAll(Guid? customerId)
        {
            if (customerId != null)
            {
                var addresses = _db.Addresses.Where(c => c.Customer.Id == customerId);
                
                return addresses.ToList();
            }
            return _db.Addresses.ToList();
        }

        public void Remove(Guid id)
        {
            _db.Addresses.Remove(_db.Addresses.FirstOrDefault(a => a.Id == id));
            Update();
        }

        public void Update()
        {
            _db.SaveDbChanges();
        }
    }
}