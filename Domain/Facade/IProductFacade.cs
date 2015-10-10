using System;
using System.Collections.Generic;

namespace Domain.Facade
{
    public interface IProductFacade
    {
        Product Get(Guid productId);
        IList<Product> GetAll();
        bool Add(Product product);
    }
}