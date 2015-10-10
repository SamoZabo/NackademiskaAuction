using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NA.Domain.DomainClasses;
using NA.Domain.Exception;
using NA.Domain.Facade;
using NA.Tests.FakeRepository;

namespace NA.Tests
{
    [TestClass]
    public class AuctionFacadeTests
    {
        private AuctionFacade sut;
        

        [TestInitialize]
        public void SetUp()
        {
            var auctionRespository = new FakeAuctionRepository();
            var productRespository = new FakeProductRepository();

            productRespository.Add(new AntiqueProduct());
            auctionRespository.AddAuction(new Auction());
            sut = new AuctionFacade(auctionRespository, productRespository);
        }

        [TestMethod]
        public void AuctionCanBeAdded()
        {
            sut.Create(1, DateTime.Now, DateTime.Now.AddHours(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ProductNotExistException))]
        public void AuctionCanNotBeAddedIfProductNotExists()
        {
            sut.Create(1001, DateTime.Now, DateTime.Now.AddHours(3));
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeBeforeStartTimeException))]
        public void AuctionCanNotBeAddedIfEndTimeIsEarlierThanStartTime()
        {
            sut.Create(1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(-3));
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeEarlierThanNowException))]
        public void AuctionCanNotBeAddedIfEndTimeIsEarlierThanNow()
        {
            sut.Create(1, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1).AddHours(3));
        }

        [TestMethod]
        public void AuctionCanBeRetrieved()
        {
            var auction = sut.Get(1);
            Assert.IsNotNull(auction);
            Assert.AreEqual(auction.Id, 1);
        }

        [TestMethod]
        public void AuctionCanNotBeRetrievedIfNull()
        {
            var auction = sut.Get(1001);
            Assert.IsNull(auction);
        }

    }
}
