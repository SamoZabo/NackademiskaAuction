using System;
using System.Collections.Generic;
using NA.Domain.DomainClasses;

namespace NA.Domain.Facade
{
    public interface IAuctionFacade
    {
        void Create(Guid acutionId, Guid productId, DateTime startTime, DateTime endTime);
        Auction Get(Guid id);
        void PlaceBid(Guid bidId, Guid auctionId, decimal amount, DateTime bidTime, Customer customer);
        Bid EndAuction(Guid auctionId);
        IList<Auction> GetAll();
        IList<Auction> GetAllActive();
    }
}
