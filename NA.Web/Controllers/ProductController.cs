using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NA.Domain.Facade;
using NA.Web.Models.Product;

namespace NA.Web.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(_productFacade.GetAll().Select(p => new ProductViewModel(p)));
        }
    }
}