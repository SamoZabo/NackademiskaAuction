using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NA.Domain.DomainClasses;
using NA.Domain.Exception;
using NA.Domain.Facade;
using NA.Web.Models.Account;

namespace NA.Web.Controllers
{
    public class AccountController : ControllerBase
    {
        public AccountController(ICustomerFacade customerFacade)
            : base(customerFacade)
        {

        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerFacade.LogIn(model.Email, model.Password);
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                catch (CustomerException e)
                {
                    return View("~/Views/Shared/ErrorView/ErrorView.cshtml", e);
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IList<Address> addresses = new List<Address>();
                foreach (var address in model.Addresses)
                {
                    var newAddress = new Address
                    {
                        AddressType = (AddressType) address.AddressType,
                        City = address.City,
                        Country = address.Country,
                        Id = Guid.NewGuid(),
                        PostalCode = address.PostalCode,
                        Street = address.Street
                    };
                    addresses.Add(newAddress);
                }
                try
                {
                    _customerFacade.Add
                    (Guid.NewGuid(), model.FirstName, model.LastName,
                    addresses, model.Password, model.ConfirmPassword,
                    model.Email);
                }
                catch (CustomerException e)
                {
                    return View("~/Views/Shared/ErrorView/ErrorView.cshtml", e);
                }

                return RedirectToAction("Index","Home");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            _customerFacade.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}