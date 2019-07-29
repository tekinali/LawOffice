using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.MvcWebUI.Areas.Admin.ViewModels.Home;
using LawOffice.Business.Abstract;
using System.Web.Security;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Areas.Admin.Controllers
{
    [Exc]
    [Auth]
    [AuthAdmin]
    public class HomeController : Controller
    {
        private IBlogService _blogService;
        private IUserService _userService;
        private IQuestionService _questionService;
        

        public HomeController(IBlogService blogService, IUserService userService, IQuestionService questionService)
        {
            _blogService = blogService;
            _userService = userService;
            _questionService = questionService;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            model.Questions = _questionService.GetAllWithDetails().Take(5).ToList();
            model.QuestionCount = _questionService.GetAll().Count();
            model.BlogCount = _blogService.GetAll().Count();
            model.UserCount = _blogService.GetAll().Count();

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}