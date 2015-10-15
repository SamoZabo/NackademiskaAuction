using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NA.Web.Models.Auction
{
    public class BidViewModel
    {
        public BidViewModel(Domain.DomainClasses.Bid bid)
        {
            Id = bid.Id;
            CustomerName = bid.Customer.FirstName +" " + bid.Customer.LastName;
            Time = bid.Time;
            Amount = bid.Amount;
        }

        public Guid Id { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Bid Time")]
        public DateTime Time { get; set; }

        public decimal Amount { get; set; }
    }
}