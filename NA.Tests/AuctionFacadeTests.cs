using System;
using Domain;
using Domain.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = sut.Create(1, DateTime.Now, DateTime.Now.AddHours(3));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AuctionCanNotBeAddedIfProductNotExists()
        {
            var result = sut.Create(1001, DateTime.Now, DateTime.Now.AddHours(3));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AuctionCanNotBeAddedIfEndTimeIsEarlierThanStartTime()
        {
            var result = sut.Create(1, DateTime.Now, DateTime.Now.AddHours(-3));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AuctionCanNotBeAddedIfEndTimeIsEarlierThanNow()
        {
            var result = sut.Create(1, DateTime.Now, DateTime.Now.AddHours(-3));
            Assert.IsFalse(result);
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
