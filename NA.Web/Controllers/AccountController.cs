using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}