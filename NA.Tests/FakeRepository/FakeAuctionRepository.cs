using System;
using System.Collections.Generic;
using System.Linq;
using NA.Domain.DomainClasses;
using NA.Domain.Repository;

namespace NA.Tests.FakeRepository
{
    public class FakeAuctionRepository : IAuctionRepository
    {
        IList<Auction> auctions = new List<Auction>();
        public Auction Get(Guid id)
        {
            return auctions.FirstOrDefault(a => a.Id == id);
        }

        public IList<Auction> GetAuctions()
        {
            return auctions;
        }

        public void AddBid(Guid auctionId, Bid bid)
        {
            var auction = Get(auctionId);
            if (auction != null)
            {
                auction.Bids.Add(bid);
            }

        }

        public void AddAuction(Auction auction)
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
