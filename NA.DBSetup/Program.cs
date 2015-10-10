using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.DataLayer.DbContext;
using NA.Domain.DomainClasses;
using NA.Domain.Facade;
using NA.Domain.Factory;
using NA.Domain.Repository;
using NA.Web.Repository;

namespace NA.DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            var ef = new EFContext();
            IProductRepository repo = new ProductRespository(ef);
            ICustomerRepository cusRepo = new CustomerRepository(ef);
            IAddressRepository adrRepo = new AddressRepository(ef);
            var facade = new CustomerFacade(cusRepo, adrRepo);

            var customer = facade.GetAll().First();

            customer.FirstName = "Kalle";
            var oldList = customer.Addresses;
            foreach (var adr in oldList)
            {
                Console.WriteLine(adr.Street);
            }
            
            IList<Address> newAddresses = new List<Address>
            {
                new Address{ AddressType = AddressType.Home, Id = oldList.First().Id, Street = "Gata 345", City = "Staden", Country = "Landet", PostalCode = "12345"}
            };

            customer.Addresses = newAddresses;
            
            facade.Update(customer);

            customer = facade.Get(customer.Id);

            foreach (var adr in customer.Addresses)
            {
                Console.WriteLine(adr.Street);
            }

            Console.ReadLine();
        }
    }
}
