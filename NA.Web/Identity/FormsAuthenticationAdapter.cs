using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using NA.Domain.Identity;

namespace NA.Web.Identity
{
    public class FormsAuthenticationAdapter : IAuth
    {
        public void DoAuth(string email)
        {
            FormsAuthentication.SetAuthCookie(email, true);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}