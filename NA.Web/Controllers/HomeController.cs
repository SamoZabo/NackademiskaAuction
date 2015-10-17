﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NA.Domain.Facade;
using NA.Web.Models.Home;

namespace NA.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IAuctionFacade _auctionFacade;

        public HomeController(IAuctionFacade auctionFacade)
        {
            _auctionFacade = auctionFacade;
        }

        public ActionResult Index()
        {
            var auctions = _auctionFacade.GetAllActive().Select(a => new AuctionListViewModel(a))
                .OrderBy(b => b.EndTime);
            return View(auctions);
        }

        public ActionResult ViewAuction(Guid id)
        {

            return View();
        }
    }
}