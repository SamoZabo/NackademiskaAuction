using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Domain.DomainClasses;

namespace NA.Domain.Facade
{
    public interface ICustomerFacade
    {
        Customer Get(Guid id);
        IList<Customer> GetAll();
        void Add(Guid id, string firstName, string lastName, IList<Address> addresses);
        void Update(Customer customer);
    }
}
