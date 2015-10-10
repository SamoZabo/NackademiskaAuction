using System;

namespace NA.Domain.DomainClasses
{
    public abstract class Product
    {
        protected Product()
        {
            IsSold = false;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Provision { get; set; }
        public decimal StartPrice { get; set; }
        public Supplier Supplier { get; set; }
        public bool IsSold { get; set; }

        public virtual decimal GetStartPrice()
        {
            return StartPrice;
        }
    }
}
