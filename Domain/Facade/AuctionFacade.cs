using System;
using System.Collections.Generic;
using System.Linq;
using NA.Domain.DomainClasses;
using NA.Domain.Exception;
using NA.Domain.Repository;

namespace NA.Domain.Facade
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

        public void Create(Guid auctionId, Guid productId, DateTime startTime, DateTime endTime)
        {
            if (endTime < startTime)
            {
                throw new EndTimeBeforeStartTimeException(
                    string.Format("End time {0} cannot be earlier than start time {1}", endTime, startTime));
            }
            if (endTime < DateTime.Now)
            {
                throw new EndTimeEarlierThanNowException(string.Format("End time {0} cannot be earlier than now",
                    endTime));
            }
            var product = _productRepository.Get(productId);
            if (product == null)
            {
                throw new ProductNotExistException(string.Format("Product with id {0} does not exist", productId));
            }
            if (product.IsSold)
            {
                throw new ProductIsSoldException(product.Name);
            }
            if (_auctionRespository.GetAuctions().Any(a => a.IsActive && a.Product.Id == productId))
            {
                throw new ProductHasActiveAuctionException(product.Name);
            }

            var auction = new Auction
            {
                Id = auctionId,
                AcceptedPrice = product.GetStartPrice() * (decimal)1.5,
                Product = product,
                StartTime = startTime,
                EndTime = endTime,
                IsActive = startTime < DateTime.Now
            };
            _auctionRespository.AddAuction(auction);
        }

        public Auction Get(Guid id)
        {
            return _auctionRespository.Get(id);
        }

        public void PlaceBid(Guid bidId, Guid auctionId, decimal amount, DateTime bidTime, Customer customer)
        {
            var auction = Get(auctionId);
            if (customer == null) throw new CustomerNotExistException("Customer does not exist");
            if (auction == null) throw new AuctionNotExistException();

            if (bidTime < auction.StartTime || bidTime > auction.EndTime)
                throw new BidTimeToEarlyOrToLateException();

            if (amount < auction.Product.GetStartPrice())
                throw new BidAmountToSmallException(amount, auction.Product.GetStartPrice());

            var lastestBid = auction.Bids.OrderBy(b => b.Amount).LastOrDefault();
            if (lastestBid != null && amount < lastestBid.Amount)
                throw new BidAmountToSmallException(amount, lastestBid.Amount);

            var bid = new Bid { Id = bidId, Customer = customer, Amount = amount, Time = bidTime };
            _auctionRespository.AddBid(auction.Id, bid);
            if (bid.Amount >= auction.AcceptedPrice)
            {
                EndAuction(auction.Id);
            }
        }

        public Bid EndAuction(Guid auctionId)
        {
            var auction = Get(auctionId);
            if (auction == null)
                throw new AuctionNotExistException();

            auction.IsActive = false;
            _auctionRespository.Update();
            if (auction.Bids.Any())
            {
                auction.Product.IsSold = true;
                _productRepository.Update();
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
