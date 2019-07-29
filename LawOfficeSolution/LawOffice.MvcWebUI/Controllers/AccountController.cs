using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.MvcWebUI.ViewModels.Account;
using LawOffice.Business.Abstract;
using LawOffice.Entities.Concrete;
using LawOffice.Core.CrossCuttingConcerns.Security.Web;
using LawOffice.Core.CrossCuttingConcerns.Security;
using System.Web.Security;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Controllers
{
    [Exc]
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userService.LoginUser(model.UserName, model.Password);
                if(user!=null)
                {
                    AuthenticationHelper.CreateAuthCookie(new Guid(), 
                        user.Id,
                        user.UserName, 
                        user.Email, 
                        DateTime.Now.AddHours(1), 
                        _userService.GetUserRolesStringName(user.Id).ToArray(), 
                        false, 
                        user.FirstName, 
                        user.LastName);
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
            }        

            return View(model);
        }


        public ActionResult LoginAdmin()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.LoginAdmin(model.UserName, model.Password);
                if (user != null)
                {
                    AuthenticationHelper.CreateAuthCookie(new Guid(),
                        user.Id,
                        user.UserName,
                        user.Email,
                        DateTime.Now.AddHours(1),
                        _userService.GetUserRolesStringName(user.Id).ToArray(),
                        false,
                        user.FirstName,
                        user.LastName);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }

            return View(model);
        }


    }
}