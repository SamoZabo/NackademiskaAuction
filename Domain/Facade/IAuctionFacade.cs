using System;
using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Facade
{
    public interface IAuctionFacade
    {
        void Create(int productId, DateTime startTime, DateTime endTime);
        Auction Get(int id);
        void PlaceBid(int auctionId, decimal amount, DateTime bidTime, Customer customer);
        Bid EndAuction(int auctionId);
        IList<Auction> GetAll();
        IList<Auction> GetAllActive();
    }
}
