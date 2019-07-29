using LawOffice.Core.CrossCuttingConcerns.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawOffice.MvcWebUI.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var identity = (Identity)System.Web.HttpContext.Current.User.Identity;
            if(identity==null)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }

        }
    }
}