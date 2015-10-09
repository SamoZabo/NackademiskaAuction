using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repository;

namespace NA.Tests.FakeRepository
{
    public class FakeProductRepository : IProductRepository
    {
        private IList<Product> products = new List<Product>();
        private int nextProductId = 1;
        public Domain.Product Get(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Domain.Product product)
        {
            if (product != null)
            {
                product.Id = nextProductId;
                nextProductId++;
                products.Add(product);
            }
        }

        public void Update(Domain.Product product)
        {
            var currentProduct = Get(product.Id);
            if (currentProduct != null)
            {
                products.Remove(currentProduct);
                products.Add(product);
            }
        }

        public IList<Domain.Product> GetAll()
        {
            return products;
        }
    }
}
