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
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IList<Domain.DomainClasses.Customer> GetAll()
        {
            return _db.Customers.ToList();
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
    }
}