using System;
using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Facade
{
    public interface IProductFacade
    {
        Product Get(Guid productId);
        IList<Product> GetAll();
        bool Add(Product product);
        IList<Designer> GetDesigners();
        IList<Supplier> GetSuppliers();
    }
}