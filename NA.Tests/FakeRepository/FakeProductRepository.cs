using System.Collections.Generic;
using System.Linq;
using NA.Domain.DomainClasses;
using NA.Domain.Repository;

namespace NA.Tests.FakeRepository
{
    public class FakeProductRepository : IProductRepository
    {
        private IList<Product> products = new List<Product>();
        private int nextProductId = 1;
        public Product Get(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            if (product != null)
            {
                product.Id = nextProductId;
                nextProductId++;
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
