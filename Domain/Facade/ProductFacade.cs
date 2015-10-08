using System.Collections.Generic;
using Domain.Repository;

namespace Domain.Facade
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository _productRepository;

        public ProductFacade(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Get(int productId)
        {
            return _productRepository.Get(productId);
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        
        public bool Add(Product product)
        {
            if (product == null)
            {
                return false;
            }
            _productRepository.Add(product);
            return true;
        }
    }
}