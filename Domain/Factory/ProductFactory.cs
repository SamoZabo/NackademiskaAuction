using System;
using NA.Domain.DomainClasses;

namespace NA.Domain.Factory
{
    public class ProductFactory : IProductFactory
    {
        public Product Create(ProductType productType, Guid productId, string name, decimal provision, 
            decimal startprice, Supplier supplier)
        {
            switch (productType)
            {
                case ProductType.Antique:
                    return new AntiqueProduct
                    {
                        Id = productId,
                        Name = name,
                        Provision = provision,
                        StartPrice = startprice,
                        Supplier = supplier
                    };
                case ProductType.Mass:
                    return new MassProduct
                    {
                        Id = productId,
                        Name = name,
                        Provision = provision,
                        StartPrice = startprice,
                        Supplier = supplier
                    };
                case ProductType.Modern:
                    return new ModernProduct
                    {
                        Id = productId,
                        Name = name,
                        Provision = provision,
                        StartPrice = startprice,
                        Supplier = supplier
                    };
                default:
                    return null;
            }
        }
    }
}