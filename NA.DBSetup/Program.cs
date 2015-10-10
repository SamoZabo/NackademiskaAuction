using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.DataLayer.DbContext;
using NA.Domain.DomainClasses;
using NA.Domain.Factory;
using NA.Domain.Repository;
using NA.Web.Repository;

namespace NA.DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {

           IProductRepository repo = new ProductRespository(new EFContext());

            var product = repo.GetAll().First();
            Console.WriteLine(product.Name);
            product.Name = Console.ReadLine();
            repo.Update();
            Console.WriteLine(product.Name);
            

        }
    }
}
