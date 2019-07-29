using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LawOffice.Business.Abstract;
using LawOffice.Entities.Concrete;
using LawOffice.MvcWebUI.Areas.Admin.ViewModels.User;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Areas.Admin.Controllers
{
    [Exc]
    [Auth]
    [AuthAdmin]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IBlogService _blogService;
        private IUserAreaService _userAreaService;
        private IUserRoleService _userRoleService;
        private IAnswerService _answerService;
        private IFieldsOfLawService _fieldsOfLawService;

        public UserController(IUserService userService, IBlogService blogService, 
            IUserAreaService userAreaService, IUserRoleService userRoleService,
            IAnswerService answerService, IFieldsOfLawService fieldsOfLawService)
        {
            _userService = userService;
            _blogService = blogService;
            _userAreaService = userAreaService;
            _userRoleService = userRoleService;
            _answerService = answerService;
            _fieldsOfLawService = fieldsOfLawService;
        }
        
        
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Users = _userService.GetAll();


            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Create(AppUser model)
        {                       
            _userService.Add(model);

            return RedirectToAction("Index","User");
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = _userService.Find(x => x.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel model = new DetailsViewModel();
            model.User = user;
            model.Blogs = _blogService.List(x => x.AppUserId == id);
            model.FieldsOfLaw = _userAreaService.ListWithDetails(x => x.AppUserId == id).Select(s => s.FieldsOfLaw).ToList();
            model.Roles = _userRoleService.ListWithDetails(x=>x.AppUserId==id).Select(s=>s.AppRole).ToList();
            model.Answers = _answerService.ListWithDetails(x => x.AppUserId == id);

            return View(model);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = _userService.Find(x => x.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            EditViewModel model = new EditViewModel();
            model.User = user;
            model.FieldsOfLaw = _userAreaService.ListWithDetails(x => x.AppUserId == id).Select(s => s.FieldsOfLaw).ToList();
            model.Roles = _userRoleService.ListWithDetails(x => x.AppUserId == id).Select(s => s.AppRole).ToList();

            var lawList = _fieldsOfLawService.GetAll();
            ViewBag.lawId = new SelectList(lawList, "Id", "Name");


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppUser model)
        {         
            try
            {
                var user = _userService.Find(x => x.Id == model.Id);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;

                _userService.Update(user);
                return RedirectToAction("Details","User",new {id=model.Id });
            }
            catch
            {
                return RedirectToAction("Edit", "User", new { id = model.Id });
            }      
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFieldOfLawToUser(Guid userId, int lawId)
        {
            try
            {
                var userArea = new UserArea()
                {
                    AppUserId=userId,
                    FieldsOfLawId=lawId
                };

                var result = _userAreaService.Add(userArea);

                return RedirectToAction("Edit", "User", new { id = userId });
            }
            catch
            {
                return RedirectToAction("Edit", "User", new { id = userId });
            }
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFieldOfLawFromUser(Guid userId, int lawId)
        {
            try
            {
                var userArea = _userAreaService.Find(x => x.AppUserId == userId && x.FieldsOfLawId == lawId);

                _userAreaService.Delete(userArea);

                return RedirectToAction("Edit", "User", new { id = userId });
            }
            catch
            {
                return RedirectToAction("Edit", "User", new { id = userId });
            }
        }


    }
}