﻿using Domain.Repository;
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
        private int nextAuctionId = 1;
        private int nextBidId = 1;
        public Domain.Auction Get(int id)
        {
            return auctions.FirstOrDefault(a => a.Id == id);
        }

        public IList<Domain.Auction> GetAuctions()
        {
            return auctions;
        }

        public void AddBid(int auctionId, Domain.Bid bid)
        {
            var auction = Get(auctionId);
            if (auction != null)
            {
                bid.Id = nextBidId;
                nextBidId++;
                auction.Bids.Add(bid);
            }

        }

        public void AddAuction(Domain.Auction auction)
        {
            auction.Id = nextAuctionId;
            nextAuctionId++;
            auctions.Add(auction);
        }

        public void EndAuction(int auctionId)
        {
            var auction = Get(auctionId);
            if (auction != null)
                auction.IsActive = false;
        }
    }
}