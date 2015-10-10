using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        void Add(Product product);
        void Update(Product product);
        IList<Product> GetAll();
    }
}
