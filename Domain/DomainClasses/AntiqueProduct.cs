namespace NA.Domain.DomainClasses
{
    public class AntiqueProduct : Product
    {
        public TimeEpoch TimeEpoch { get; set; }
        public override decimal GetStartPrice()
        {
            return StartPrice * (decimal)1.2;
        }
    }

    public enum TimeEpoch
    {
        Baroque,
        Neoclassical,
        Romanticism,
        Realism,
        Impressionism
    }
}
