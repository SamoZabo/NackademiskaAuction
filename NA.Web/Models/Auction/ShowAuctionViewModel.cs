using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NA.Domain.DomainClasses;

namespace NA.Web.Models.Auction
{
    public class ShowAuctionViewModel
    {

        public ShowAuctionViewModel(Domain.DomainClasses.Auction auction)
        {
            AuctionId = auction.Id;
            ProductName = auction.Product.Name;
            TotalBid = auction.Bids.Count;
            var winningBid = auction.Bids.OrderBy(b => b.Amount).LastOrDefault();
            if (winningBid != null)
                WinningBid = winningBid.Amount;
            StartPrice = auction.Product.GetStartPrice();
            AcceptedPrice = auction.AcceptedPrice;
            StartDate = auction.StartTime;
            EndDate = auction.EndTime;
            Bids = auction.Bids.Select(b => new BidViewModel(b)).ToList();
        }

        public Guid AuctionId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Total Bids")]
        public int TotalBid { get; set; }

        [Display(Name = "Start Price")]
        public decimal StartPrice { get; set; }

        [Display(Name = "Accepted Price")]
        public decimal AcceptedPrice { get; set; }

        [Display(Name = "Winning Bid")]
        public decimal WinningBid { get; set; }

        public IList<BidViewModel> Bids { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

    }
}