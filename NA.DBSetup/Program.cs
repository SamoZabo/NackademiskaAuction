using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.DataLayer.DbContext;
using NA.Domain.DomainClasses;
using NA.Domain.Facade;
using NA.Domain.Factory;
using NA.Domain.Identity;
using NA.Domain.Repository;
using NA.Web.Repository;

namespace NA.DBSetup
{
    class Program
    {
        private static void SetUpDatabase()
        {
            var db = new EFContext();
            var customerFacade = new CustomerFacade(new CustomerRepository(db), new AddressRepository(db), null,
                new PasswordHandler());

            var productRepository = new ProductRepository(db);
            var productFacade = new ProductFacade(productRepository);
            var auctionFacade = new AuctionFacade(new AuctionRepository(db), productRepository);

            var customerId = Guid.NewGuid();
            customerFacade.Add(customerId, "Elin", "Danielsson",
                new List<Address>()
                {
                    new Address
                    {
                        AddressType = AddressType.Home,
                        City = "Nykvarn",
                        Country = "Sweden",
                        Id = Guid.NewGuid(),
                        PostalCode = "15531",
                        Street = "Skärarevägen 8"
                    }
                }, "elin", "elin", "elda2032@gmail.com");

            var adminId = Guid.NewGuid();
            customerFacade.Add(adminId, "Gunnar", "Karlsson",
                new List<Address>()
                {
                    new Address
                    {
                        AddressType = AddressType.Work,
                        City = "Stockholm",
                        Country = "Sweden",
                        Id = Guid.NewGuid(),
                        PostalCode = "12345",
                        Street = "Gatan 1"
                    }
                }, "admin", "admin", "admin@na.com");


            IProductFactory prodcuFactory = new ProductFactory();

            Supplier supplier = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = "Elin"
            };
            var product = prodcuFactory.Create(ProductType.Antique, Guid.NewGuid(), "Vas", 22, 300, supplier) as AntiqueProduct;
            product.TimeEpoch = TimeEpoch.Baroque;

            Customer customer = customerFacade.Get(customerId);

            IList<Bid> bids = new List<Bid>
            {
                new Bid {Amount = 400, Id = Guid.NewGuid(), Customer = customer, Time = DateTime.Now}
            };

            Auction auction = new Auction()
            {
                AcceptedPrice = product.GetStartPrice() * (decimal)1.5,
                Product = product,
                Id = Guid.NewGuid(),
                Bids = bids,
                StartTime = DateTime.Now.AddHours(-2),
                EndTime = DateTime.Now.AddDays(7)
            };

            db.Suppliers.Add(supplier);
            db.AntiqueProducts.Add(product);
            db.Bids.AddRange(bids);
            db.Auctions.Add(auction);

        }

        static void Main(string[] args)
        {
            //var ef = new EFContext();
            //IProductRepository repo = new ProductRepository(ef);
            //ICustomerRepository cusRepo = new CustomerRepository(ef);
            //IAddressRepository adrRepo = new AddressRepository(ef);
            //var facade = new CustomerFacade(cusRepo, adrRepo, null, null);

            //var customer = facade.GetAll().First();

            //customer.FirstName = "Kalle";
            //var oldList = customer.Addresses;
            //foreach (var adr in oldList)
            //{
            //    Console.WriteLine(adr.Street);
            //}
            
            //IList<Address> newAddresses = new List<Address>
            //{
            //    new Address{ AddressType = AddressType.Home, Id = oldList.First().Id, Street = "Gata 345", City = "Staden", Country = "Landet", PostalCode = "12345"}
            //};

            //customer.Addresses = newAddresses;
            
            //facade.Update(customer);

            //customer = facade.Get(customer.Id);

            //foreach (var adr in customer.Addresses)
            //{
            //    Console.WriteLine(adr.Street);
            //}

            SetUpDatabase();

            Console.ReadLine();
        }
    }
}
