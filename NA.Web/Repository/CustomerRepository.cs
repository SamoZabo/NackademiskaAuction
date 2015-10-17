using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NA.DataLayer.DbContext;
using NA.Domain.Repository;

namespace NA.Web.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IEFContext _db;

        public CustomerRepository(IEFContext db)
        {
            _db = db;
        }
        public Domain.DomainClasses.Customer Get(Guid id)
        
        {
            var adrs = _db.Customers.Include("Addresses").FirstOrDefault(c => c.Id == id);
            return adrs;
        }

        public IList<Domain.DomainClasses.Customer> GetAll()
        {
            return _db.Customers.Include("Addresses").ToList();
        }

        public void Add(Domain.DomainClasses.Customer customer)
        {
            _db.Customers.Add(customer);
            Update();
        }

        public void Update()
        {
            _db.SaveDbChanges();
        }


        public Domain.DomainClasses.Customer GetByEmail(string email)
        {
            return _db.Customers.FirstOrDefault(c => c.Email == email);
        }
    }
}