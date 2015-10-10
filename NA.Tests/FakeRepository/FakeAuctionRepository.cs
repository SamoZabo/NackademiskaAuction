using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace NA.Tests.FakeRepository
{
    public class FakeAuctionRepository : IAuctionRepository
    {
        IList<Auction> auctions = new List<Auction>();
        public Domain.Auction Get(Guid id)
        {
            return auctions.FirstOrDefault(a => a.Id == id);
        }

        public IList<Domain.Auction> GetAuctions()
        {
            return auctions;
        }

        public void AddBid(Guid auctionId, Domain.Bid bid)
        {
            var auction = Get(auctionId);
            if (auction != null)
            {
                auction.Bids.Add(bid);
            }

        }

        public void AddAuction(Domain.Auction auction)
        {
            auctions.Add(auction);
        }

        public void EndAuction(Guid auctionId)
        {
            var auction = Get(auctionId);
            if (auction != null)
                auction.IsActive = false;
        }
    }
}
