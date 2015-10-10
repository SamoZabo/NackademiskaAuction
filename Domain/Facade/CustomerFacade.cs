using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Domain.DomainClasses;
using NA.Domain.Repository;

namespace NA.Domain.Facade
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CustomerFacade(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }


        public Customer Get(Guid id)
        {
            return _customerRepository.Get(id); 
        }

        public IList<DomainClasses.Customer> GetAll()
        {
           return _customerRepository.GetAll();
        }

        public void Add(Guid id, string firstName, string lastName, IList<DomainClasses.Address> addresses)
        {
            var customer = new Customer {Id = id, FirstName = firstName, LastName = lastName, Addresses = addresses};
            _customerRepository.Add(customer);
        }

        public void Update(Customer customer)
        {
            var oldAddresses = _addressRepository.GetAll(customer.Id);

            foreach (var address in oldAddresses)
                _addressRepository.Remove(address.Id);
            
            _customerRepository.Update();
        }
    }
}
