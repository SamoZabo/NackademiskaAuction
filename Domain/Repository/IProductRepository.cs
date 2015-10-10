using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Repository
{
    public interface IProductRepository
    {
        Product Get(int id);
        void Add(Product product);
        void Update(Product product);
        IList<Product> GetAll();
    }
}
