using System;

namespace NA.Domain.DomainClasses
{
    public class Bid
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
    }
}
