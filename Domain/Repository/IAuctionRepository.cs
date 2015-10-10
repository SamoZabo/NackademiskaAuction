using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAuctionRepository
    {
        Auction Get(Guid id);
        IList<Auction> GetAuctions();
        void AddBid(Guid auctionId, Bid bid);
        void AddAuction(Auction auction);
        void EndAuction(Guid auctionId);
    }
}
