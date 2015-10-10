using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Repository
{
    public interface IAuctionRepository
    {
        Auction Get(int id);
        IList<Auction> GetAuctions();
        void AddBid(int auctionId, Bid bid);
        void AddAuction(Auction auction);
        void EndAuction(int auctionId);
    }
}
