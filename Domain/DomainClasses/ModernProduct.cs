namespace NA.Domain.DomainClasses
{
    public class ModernProduct : DesignerProduct
    {
        public override decimal GetStartPrice()
        {
            return StartPrice*(decimal)1.1;
        }
    }
}
