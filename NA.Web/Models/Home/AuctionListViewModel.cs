using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NA.Web.Models.Auction;

namespace NA.Web.Models.Home
{
    public class AuctionListViewModel
    {
        public AuctionListViewModel(Domain.DomainClasses.Auction auction)
        {
            AuctionId = auction.Id;
            ProductName = auction.Product.Name;
            TotalBids = auction.Bids.Count;
            var winningBid = auction.Bids.OrderBy(b => b.Amount).LastOrDefault();
            CurrentPrice = winningBid != null 
                ? winningBid.Amount 
                : auction.Product.GetStartPrice();
            AcceptedPrice = auction.AcceptedPrice;
            RemainingTime = auction.EndTime - DateTime.Now;
        }

        public Guid AuctionId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Total Bids")]
        public int TotalBids { get; set; }

        [Display(Name = "Current Price")]
        public decimal CurrentPrice { get; set; }

        [Display(Name = "Accepted Price")]
        public decimal AcceptedPrice { get; set; }

        [Display(Name = "Remaining Time")]
        public TimeSpan RemainingTime { get; set; }

    }
}