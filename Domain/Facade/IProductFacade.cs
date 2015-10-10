using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Facade
{
    public interface IProductFacade
    {
        Product Get(int productId);
        IList<Product> GetAll();
        bool Add(Product product);
    }
}