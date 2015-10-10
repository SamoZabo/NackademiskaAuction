using System;
using Domain;
using Domain.Exception;
using Domain.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NA.Tests.FakeRepository;

namespace NA.Tests
{
    [TestClass]
    public class AuctionFacadeTests
    {
        private AuctionFacade sut;
        private Guid productId = Guid.NewGuid();
        private Guid auciontId = Guid.NewGuid();



        [TestInitialize]
        public void SetUp()
        {
            var auctionRespository = new FakeAuctionRepository();
            var productRespository = new FakeProductRepository();

            productRespository.Add(new AntiqueProduct() { Id = productId });
            auctionRespository.AddAuction(new Auction() { Id = auciontId });
            sut = new AuctionFacade(auctionRespository, productRespository);
        }

        [TestMethod]
        public void AuctionCanBeAdded()
        {
            sut.Create(Guid.NewGuid(), productId, DateTime.Now, DateTime.Now.AddHours(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ProductNotExistException))]
        public void AuctionCanNotBeAddedIfProductNotExists()
        {
            sut.Create(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now.AddHours(3));
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeBeforeStartTimeException))]
        public void AuctionCanNotBeAddedIfEndTimeIsEarlierThanStartTime()
        {
            sut.Create(Guid.NewGuid(), productId, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(-3));
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeEarlierThanNowException))]
        public void AuctionCanNotBeAddedIfEndTimeIsEarlierThanNow()
        {
            sut.Create(Guid.NewGuid(), productId, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1).AddHours(3));
        }

        [TestMethod]
        public void AuctionCanBeRetrieved()
        {
            var auction = sut.Get(auciontId);
            Assert.IsNotNull(auction);
            Assert.AreEqual(auction.Id, auciontId);
        }

        [TestMethod]
        public void AuctionCanNotBeRetrievedIfNull()
        {
            var auction = sut.Get(Guid.NewGuid());
            Assert.IsNull(auction);
        }

    }
}
