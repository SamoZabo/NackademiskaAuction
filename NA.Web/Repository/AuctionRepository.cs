using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NA.DataLayer.DbContext;
using NA.Domain.Repository;

namespace NA.Web.Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly IEFContext _db;

        public AuctionRepository(IEFContext db)
        {
            _db = db;
        }
        public Domain.DomainClasses.Auction Get(Guid id)
        {
            return _db.Auctions.Include("Product").Include("Bids").Include("Bids.Customer").FirstOrDefault(a => a.Id == id);
        }

        public IList<Domain.DomainClasses.Auction> GetAuctions()
        {
            return _db.Auctions.Include("Product").Include("Bids").Include("Bids.Customer").ToList();
        }

        public void AddBid(Guid auctionId, Domain.DomainClasses.Bid bid)
        {
            var auction = Get(auctionId);
            auction.Bids.Add(bid);
            Update();
        }

        public void AddAuction(Domain.DomainClasses.Auction auction)
        {
            auction.Product = _db.Products.First(p => auction.Product.Id == p.Id);
            _db.Auctions.Add(auction);
            Update();
        }

        public void Update()
        {
            _db.SaveDbChanges();
        }
    }
}