using System;
using NA.Domain.DomainClasses;

namespace NA.Domain.Factory
{
    public enum ProductType
    {
        Mass,
        Modern,
        Antique
    }

    public interface IProductFactory
    {
        Product Create(ProductType productType, Guid productId, string name, decimal provision, decimal startprice,
            Supplier supplier);
    }
}