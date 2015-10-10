using System.Collections.Generic;
using System.Linq;
using NA.Domain.DomainClasses;
using NA.Domain.Repository;

namespace NA.Tests.FakeRepository
{
    public class FakeProductRepository : IProductRepository
    {
        private IList<Product> products = new List<Product>();
        public Product Get(Guid id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            if (product != null)
            {
                products.Add(product);
            }
        }

        public void Update(Product product)
        {
            var currentProduct = Get(product.Id);
            if (currentProduct != null)
            {
                products.Remove(currentProduct);
                products.Add(product);
            }
        }

        public IList<Product> GetAll()
        {
            return products;
        }
    }
}
