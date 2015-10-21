using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NA.Domain.Exception;
using NA.Domain.Facade;
using NA.Web.Models.Auction;

namespace NA.Web.Controllers
{
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionFacade _auctionFacade;
        private readonly IProductFacade _productFacade;
        public AuctionController(IAuctionFacade auctionFacade, IProductFacade productFacade, ICustomerFacade customerFacade)
            : base(customerFacade)
        {
            _auctionFacade = auctionFacade;
            _productFacade = productFacade;
        }


        public ActionResult Create(Guid productId)
        {
            var product = _productFacade.Get(productId);

            if (product != null)
            {
                var auction = new CreateAuctionViewModel()
                {
                    ProductId = product.Id, 
                    ProductName = product.Name, 
                    Start = DateTime.Now, 
                    End = DateTime.Now.AddDays(1)
                };
                return View(auction);
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _auctionFacade.Create(Guid.NewGuid(), model.ProductId, model.Start, model.End);
                }
                catch (AuctionException e)
                {
                    return View("~/Views/Shared/ErrorView/ErrorView.cshtml", e);
                }
            }

            return RedirectToAction("Index", "Product");
        }

        public ActionResult ViewAuction(Guid productId)
        {
            ShowAuctionViewModel model = null;
            var auction = _auctionFacade.GetByProductId(productId)
                .OrderBy(a => a.EndTime).LastOrDefault();
            if (auction != null)
            {
                model = new ShowAuctionViewModel(auction);
                return View(model);
            }
            return RedirectToAction("Create", new { productId });
        }
    }
}