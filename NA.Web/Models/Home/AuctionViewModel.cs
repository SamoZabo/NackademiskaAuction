using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NA.Web.Models.Home
{
    public class AuctionViewModel : AuctionListViewModel
    {
        public AuctionViewModel(Domain.DomainClasses.Auction auction) : base(auction)
        {
        }

        public decimal BidAmount { get; set; }

    }
}