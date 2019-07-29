using LawOffice.Business.Abstract;
using LawOffice.Core.CrossCuttingConcerns.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Filters
{
    public class AuthUser : FilterAttribute, IAuthorizationFilter
    {
     

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var identity = (Identity)System.Web.HttpContext.Current.User.Identity;
            var roles = identity.Roles;

            bool result = false;       

            foreach (var item in roles)
            {
                if(item=="StandartUser")
                {
                    result = true;
                }
            }
         

            if (result == false)
            {
                filterContext.Result = new RedirectResult("/Home/AccessDenied");
            }


        }
    }
}