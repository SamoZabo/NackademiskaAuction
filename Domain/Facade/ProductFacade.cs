using System;
using System.Collections.Generic;
using NA.Domain.DomainClasses;
using NA.Domain.Repository;

namespace NA.Domain.Facade
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository _productRepository;

        public ProductFacade(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Get(Guid productId)
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

        public IList<Designer> GetDesigners()
        {
            return _productRepository.GetDesigners();
        }

        public IList<Supplier> GetSuppliers()
        {
            return _productRepository.GetSuppliers();
        }
    }
}