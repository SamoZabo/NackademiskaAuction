using System;
using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Repository
{
    public interface IAuctionRepository
    {
        Auction Get(Guid id);
        IList<Auction> GetAuctions();
        void AddBid(Guid auctionId, Bid bid);
        void AddAuction(Auction auction);
        void Update();
    }
}
