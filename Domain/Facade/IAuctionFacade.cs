using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Facade
{
    public interface IAuctionFacade
    {
        bool Create(int productId, DateTime startTime, DateTime endTime);
        Auction Get(int id);
        bool PlaceBid(int auctionId, decimal amount, DateTime bidTime, Customer customer);
        Bid EndAuction(int auctionId);
        IList<Auction> GetAll();
    }
}
