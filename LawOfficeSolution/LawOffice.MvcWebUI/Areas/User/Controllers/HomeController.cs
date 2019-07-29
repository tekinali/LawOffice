using LawOffice.Core.CrossCuttingConcerns.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LawOffice.Entities.Concrete;
using LawOffice.Business.Abstract;
using LawOffice.MvcWebUI.Areas.User.ViewModels.Home;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Areas.User.Controllers
{
    [Exc]
    [Auth]
    [AuthUser]
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IUserAreaService _userAreaService;
        private IUserRoleService _userRoleService;
        private IFieldsOfLawService _fieldsOfLawService;
        private IQuestionService _questionService;
        private IBlogService _blogService;
        private IAnswerService _answerService;


        public HomeController(IUserService userService, IUserAreaService userAreaService,
            IUserRoleService userRoleService,IFieldsOfLawService fieldsOfLawService, IQuestionService questionService, 
            IBlogService blogService, IAnswerService answerService)
        {
            _userService = userService;
            _userAreaService = userAreaService;
            _userRoleService = userRoleService;
            _fieldsOfLawService = fieldsOfLawService;
            _questionService = questionService;
            _blogService = blogService;
            _answerService = answerService;
        }
        
        public ActionResult Index()
        {
            var userId = GetUserId();


            IndexViewModel model = new IndexViewModel();
            model.Questions = _questionService.GetAllWithDetails().Take(5).ToList();

            model.QuestionCount = _questionService.GetAll().Count();
            model.BlogCount = _blogService.List(x => x.AppUserId == userId).Count();
            model.AnswerCount = _answerService.List(x => x.AppUserId == userId).Count();


            return View(model);
        }

        public ActionResult MyInfo()
        {
            var userId = GetUserId();

            MyInfoViewModel model = new MyInfoViewModel();
            model.User = _userService.Find(x => x.Id == userId);
            model.FieldsOfLaw = _userAreaService.ListWithDetails(x => x.AppUserId == userId).Select(s => s.FieldsOfLaw).ToList();
            model.Roles = _userRoleService.ListWithDetails(x => x.AppUserId == userId).Select(s => s.AppRole).ToList();


            return View(model);
        }

        public ActionResult MyInfoEdit()
        {
            var userId = GetUserId();

            MyInfoViewModel model = new MyInfoViewModel();
            model.User = _userService.Find(x => x.Id == userId);
            model.FieldsOfLaw = _userAreaService.ListWithDetails(x => x.AppUserId == userId).Select(s => s.FieldsOfLaw).ToList();
            model.Roles = _userRoleService.ListWithDetails(x => x.AppUserId == userId).Select(s => s.AppRole).ToList();

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyInfoEdit(MyInfoEditViewModel model)
        {
            try
            {
                var userId = GetUserId();
                if(ModelState.IsValid)
                {
                    var user = _userService.Find(x => x.Id == userId);

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;

                    var result = _userService.Update(user);

                }
                else
                {
                    return RedirectToAction("MyInfoEdit", "Home");
                }
                return RedirectToAction("MyInfo", "Home");
            }
            catch
            {
                return RedirectToAction("MyInfoEdit", "Home");
            }
                

        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private Guid GetUserId()
        {
            var myIdentity = (Identity)System.Web.HttpContext.Current.User.Identity;
            var userId = myIdentity.UserId;

            return userId;
        }

    }
}