namespace Domain.Factory
{
    public class ProductFactory : IProductFactory
    {
        public Product Create(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Antique:
                    return new AntiqueProduct();
                case ProductType.Mass:
                    return new MassProduct();
                case ProductType.Modern:
                    return new ModernProduct();
                default:
                    return null;
            }
        }
    }
}