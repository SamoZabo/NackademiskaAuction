using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Domain.DomainClasses;

namespace NA.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        IList<Customer> GetAll();
        Customer GetByEmail(string email);
        void Add(Customer customer);
        void Update();
    }
}
