using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.DataLayer.DbContext;
using NA.Domain.DomainClasses;
using NA.Domain.Factory;

namespace NA.DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            EFContext db = new EFContext();

            IProductFactory prodcuFactory= new ProductFactory();
            
            Supplier supplier = new Supplier
            {
                Id = Guid.NewGuid(), 
                Name = "Elin"
            };
            var product = prodcuFactory.Create(ProductType.Antique, Guid.NewGuid(), "Vas", 22, 300, supplier) as AntiqueProduct;
            product.TimeEpoch = TimeEpoch.Baroque;
            Address homeAddress = new Address
            {
                AddressType = AddressType.Home,
                Id = Guid.NewGuid(),
                City = "Järfälla",
                Country = "Sweden",
                PostalCode = "17677",
                Street = "Termovägen 90"
            };

            Customer customer = new Customer
            {
                Addresses = new List<Address>() {homeAddress},
                Id = Guid.NewGuid(),
                FirstName = "Abi",
                LastName = "Larsson"
            };

            IList<Bid> bids = new List<Bid>
            {
                new Bid {Amount = 400, Id = Guid.NewGuid(), Customer = customer, Time = DateTime.Now}
            };

            Auction auction = new Auction()
            {
                AcceptedPrice = product.GetStartPrice()*(decimal) 1.5,
                Product = product,
                Id = Guid.NewGuid(),
                Bids = bids,
                StartTime = DateTime.Now.AddHours(-2),
                EndTime = DateTime.Now.AddDays(7)
            };

            db.Suppliers.Add(supplier);
            db.AntiqueProducts.Add(product);
            db.Addresses.Add(homeAddress);
            db.Customers.Add(customer);
            db.Bids.AddRange(bids);
            db.Auctions.Add(auction);

            db.SaveChanges();
        }
    }
}
