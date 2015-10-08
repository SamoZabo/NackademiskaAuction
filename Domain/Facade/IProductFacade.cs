using System.Collections.Generic;

namespace Domain.Facade
{
    public interface IProductFacade
    {
        Product Get(int productId);
        IList<Product> GetAll();
        bool Add(Product product);
    }
}