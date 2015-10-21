using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NA.Domain.Facade;

namespace NA.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly ICustomerFacade _customerFacade;

        public ControllerBase(ICustomerFacade customerFacade)
        {
            _customerFacade = customerFacade;
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            _customerFacade.AuthenticateRequest(filterContext.HttpContext);
            base.OnAuthorization(filterContext);
        }
    }
}