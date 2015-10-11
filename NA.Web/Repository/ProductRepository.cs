using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NA.DataLayer.DbContext;
using NA.Domain.DomainClasses;
using NA.Domain.Repository;

namespace NA.Web.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IEFContext _db;
        public ProductRepository(IEFContext db)
        {
            _db = db;
        }
        public Domain.DomainClasses.Product Get(Guid id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
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
            IEnumerable<Product> antiqueProducts =
                _db.Products.OfType<AntiqueProduct>().Include("Supplier");
            IEnumerable<Product> designerProducts =
                _db.Products.OfType<DesignerProduct>().Include("Supplier").Include("Designer");

            return antiqueProducts.Concat(designerProducts).ToList();
        }

        public IList<Designer> GetDesigners()
        {
            return _db.Designers.ToList();
        }

        public IList<Supplier> GetSuppliers()
        {
            return _db.Suppliers.ToList();
        }
    }
}