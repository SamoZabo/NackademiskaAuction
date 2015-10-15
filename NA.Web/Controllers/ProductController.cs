using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NA.Domain.DomainClasses;
using NA.Domain.Facade;
using NA.Domain.Factory;
using NA.Web.Models.Product;

namespace NA.Web.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductFacade _productFacade;
        private readonly IAuctionFacade _auctionFacade;
        private readonly IProductFactory _productFactory;

        public ProductController(IProductFacade productFacade, IAuctionFacade auctionFacade, IProductFactory productFactory)
        {
            _productFacade = productFacade;
            _auctionFacade = auctionFacade;
            _productFactory = productFactory;
        }

        public ActionResult Index()
        {
            var products = _productFacade.GetAll().Select(p => new ProductViewModel(p)).ToList();
            foreach (var product in products)
            {
                product.HasAuction = _auctionFacade.GetByProductId(product.Id).Any();
            }
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateProductViewModel();

            var productTypes = from ProductType t in Enum.GetValues(typeof(ProductType))
                               select new
                               {
                                   ID = (int)t,
                                   Name = t.ToString()
                               };
            model.ProductTypes = new SelectList(productTypes, "ID", "Name");
            model.ProductTypeId = -1;

            var timeEpochs = from TimeEpoch t in Enum.GetValues(typeof(TimeEpoch))
                             select new
                             {
                                 ID = (int)t,
                                 Name = t.ToString()
                             };
            model.TimeEpochs = new SelectList(timeEpochs, "ID", "Name");
            model.TimeEpochId = -1;

            model.Suppliers = new SelectList(_productFacade.GetSuppliers(), "Id", "Name");
            model.Designers = new SelectList(_productFacade.GetDesigners(), "Id", "Name");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var supplier = _productFacade.GetSuppliers().FirstOrDefault(s => s.Id == model.SupplierId);
                if (supplier == null)
                {
                    supplier = new Supplier { Id = Guid.NewGuid(), Name = model.SupplierName };
                }

                var product = _productFactory.Create((ProductType)model.ProductTypeId, Guid.NewGuid(), model.Name,
                    model.Provision, model.StartPrice, supplier);

                switch ((ProductType)model.ProductTypeId)
                {
                    case ProductType.Antique:
                        (product as AntiqueProduct).TimeEpoch = (TimeEpoch)model.TimeEpochId;
                        break;
                    case ProductType.Mass:
                    case ProductType.Modern:
                        var designer = _productFacade.GetDesigners().FirstOrDefault(d => d.Id == model.DesignerId);
                        if (designer == null)
                        {
                            designer = new Designer { Id = Guid.NewGuid(), Name = model.DesignerName };
                        }
                        (product as DesignerProduct).Designer = designer;
                        break;
                    default:
                        break;
                }
                _productFacade.Add(product);
            }
            return RedirectToAction("Index");
        }
    }
}