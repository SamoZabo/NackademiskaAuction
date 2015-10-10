using System;
using System.Collections.Generic;

namespace NA.Domain.DomainClasses
{
    public class Auction
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal AcceptedPrice { get; set; }
        public IList<Bid> Bids { get; set; } 
    }
}