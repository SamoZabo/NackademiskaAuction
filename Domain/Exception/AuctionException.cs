using System;

namespace NA.Domain.Exception
{
    public class AuctionException : ApplicationException
    {
        public AuctionException(string message) : base(message)
        {
        }
    }

    public class EndTimeBeforeStartTimeException : AuctionException
    {
        public EndTimeBeforeStartTimeException(string message) : base(message)
        {
        }
    }

    public class EndTimeEarlierThanNowException : AuctionException
    {
        public EndTimeEarlierThanNowException(string message) : base(message)
        {
        }
    }

    public class ProductNotExistException : AuctionException
    {
        public ProductNotExistException(string message) : base(message)
        {
        }
    }

    public class CustomerNotExistException : AuctionException
    {
        public CustomerNotExistException(string message) : base(message)
        {
        }
    }

    public class AuctionNotExistException : AuctionException
    {
        public AuctionNotExistException() : base("Auction does not exist")
        {
        }
    }

    public class BidAmountToSmallException : AuctionException
    {
        public BidAmountToSmallException(decimal bidamount, decimal largerthan) 
            : base(string.Format("Amount {0} to low, must be larger than {1}", bidamount, largerthan))
        {
        }
    }

    public class BidTimeToEarlyOrToLateException : AuctionException
    {
        public BidTimeToEarlyOrToLateException() : base("Invalid bid time, auction is not open")
        {
        }
    }

    public class ProductIsSoldException : AuctionException
    {
        public ProductIsSoldException(string productName) : base(string.Format("{0} is sold", productName))
        {
        }
    }

    public class ProductHasActiveAuctionException : AuctionException
    {
        public ProductHasActiveAuctionException(string productName) 
            : base(string.Format("{0} is already in auction", productName))
        {
        }
    }
}