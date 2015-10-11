using System;
using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Repository
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        void Add(Product product);
        void Update();
        IList<Product> GetAll();
        IList<Designer> GetDesigners();
        IList<Supplier> GetSuppliers();
    }
}
