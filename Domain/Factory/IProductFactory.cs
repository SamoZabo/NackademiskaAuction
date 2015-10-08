namespace Domain.Factory
{
    public enum ProductType
    {
        Mass,
        Modern,
        Antique
    }

    public interface IProductFactory
    {
        Product Create(ProductType productType);
    }
}