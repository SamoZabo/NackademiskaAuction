using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NA.Domain.DomainClasses;
using NA.Domain.Exception;
using NA.Domain.Facade;
using NA.Web.CustomFilters;
using NA.Web.Models.Home;

namespace NA.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IAuctionFacade _auctionFacade;

        public HomeController(IAuctionFacade auctionFacade, ICustomerFacade customerFacade)
            : base(customerFacade)
        {
            _auctionFacade = auctionFacade;
        }

        public ActionResult Index()
        {
            var auctions = _auctionFacade.GetAllActive().Select(a => new AuctionListViewModel(a))
                .OrderBy(b => b.EndTime);
            return View(auctions);
        }

        [HttpPost]
        [CustomerAuthorize(Role.Customer, Role.Admin)]
        public ActionResult PlaceBid(Guid auctionId, decimal bid)
        {
            try
            {
                _auctionFacade.PlaceBid(Guid.NewGuid(), auctionId, bid, DateTime.Now, (Customer)User);
            }
            catch (AuctionException e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("Index");
        }
    }
}