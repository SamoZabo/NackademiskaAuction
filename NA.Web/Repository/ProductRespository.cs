using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NA.DataLayer.DbContext;
using NA.Domain.Repository;

namespace NA.Web.Repository
{
    public class ProductRespository : IProductRepository
    {
        private readonly IEFContext _db ;
        public ProductRespository(IEFContext db )
        {
            _db = db;
        }
        public Domain.DomainClasses.Product Get(Guid id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Domain.DomainClasses.Product product)
        {
            _db.Products.Add(product);
            Update();
        }

        public void Update()
        {
            _db.SaveDbChanges();
        }

        public IList<Domain.DomainClasses.Product> GetAll()
        {
            return _db.Products.ToList();
        }
    }
}