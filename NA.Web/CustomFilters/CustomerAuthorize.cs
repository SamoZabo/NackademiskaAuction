using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NA.Domain.DomainClasses;

namespace NA.Web.CustomFilters
{
    public class CustomerAuthorize : AuthorizeAttribute
    {
        public Role CustomerRole { get; set; }

        public CustomerAuthorize(Role role)
        {
            CustomerRole = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var customer = httpContext.User;
            if (customer == null)
                return false;
            if (!customer.Identity.IsAuthenticated)
                return false;
            return customer.IsInRole(CustomerRole.ToString());
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string returnUrl = null;
                if (filterContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
                {
                    returnUrl = filterContext.HttpContext.Request.RawUrl;
                }
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Account", action = "Login", returnUrl }
                        ));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Account", action = "NotAuthorized" }
                        )
                        );
            }
        }
    }
}