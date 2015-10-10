using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.DataLayer.DbContext;
using NA.Domain.DomainClasses;

namespace NA.DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            EFContext db = new EFContext();

            db.Suppliers.Add(new Supplier() {Id = Guid.NewGuid(), Name = "Elin"});
            db.SaveChanges();
        }
    }
}
