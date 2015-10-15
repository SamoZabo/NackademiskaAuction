using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NA.Web.Models.Auction
{
    public class CreateAuctionViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}