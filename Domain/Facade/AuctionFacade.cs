using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository;

namespace Domain.Facade
{
    public class AuctionFacade : IAuctionFacade
    {
        private readonly IAuctionRepository _auctionRespository;
        private readonly IProductRepository _productRepository;

        public AuctionFacade(IAuctionRepository auctionRespository, IProductRepository productRepository)
        {
            _auctionRespository = auctionRespository;
            _productRepository = productRepository;
        }

        public bool Create(int productId, DateTime startTime, DateTime endTime)
        {
            if (endTime < startTime || endTime < DateTime.Now)
            {
                return false;
            }
            var product = _productRepository.Get(productId);
            if (product == null)
            {
                return false;
            }
            var auction = new Auction
            {
                AcceptedPrice = product.GetStartPrice() * (decimal)1.5,
                Product = product,
                StartTime = startTime,
                EndTime = endTime,
                IsActive = startTime < DateTime.Now
            };
            _auctionRespository.AddAuction(auction);
            return true;
        }

        public Auction Get(int id)
        {
            return _auctionRespository.Get(id);
        }

        public bool PlaceBid(int auctionId, decimal amount, DateTime bidTime, Customer customer)
        {
            var auction = Get(auctionId);
            if (customer == null || auction == null)
                return false;
            if (bidTime < auction.StartTime || bidTime > auction.EndTime)
                return false;
            if (amount < auction.Product.GetStartPrice())
                return false;
            var lastestBid = auction.Bids.OrderBy(b => b.Amount).LastOrDefault();
            if (lastestBid != null && amount < lastestBid.Amount)
                return false;
            var bid = new Bid { Customer = customer, Amount = amount, Time = bidTime };
            _auctionRespository.AddBid(auction.Id, bid);
            if (bid.Amount >= auction.AcceptedPrice)
            {
                EndAuction(auction.Id);
                return true;
            }
            return true;
        }

        public Bid EndAuction(int auctionId)
        {
            var auction = Get(auctionId);
            if (auction == null)
                return null;
            _auctionRespository.EndAuction(auction.Id);
            if (auction.Bids.Any())
            {
                auction.Product.IsSold = true;
                _productRepository.Update(auction.Product);
            }
            return auction.Bids.OrderBy(b => b.Amount).LastOrDefault();
        }

        public IList<Auction> GetAll()
        {
            return _auctionRespository.GetAuctions() ?? new List<Auction>();
        }

        public IList<Auction> GetAllActive()
        {
            return GetAll().Where(a => a.IsActive).ToList();
        }
    }
}
