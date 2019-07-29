using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LawOffice.Business.Abstract;
using LawOffice.Entities.Concrete;
using LawOffice.MvcWebUI.Areas.Admin.ViewModels.FieldsOfLaw;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Areas.Admin.Controllers
{
    [Exc]
    [Auth]
    [AuthAdmin]
    public class FieldsOfLawController : Controller
    {
        private IFieldsOfLawService _fieldsOfLawService;
        private IUserAreaService _userAreaService;
        private IUserService _userService;

        public FieldsOfLawController(IFieldsOfLawService fieldsOfLawService, IUserAreaService userAreaService, IUserService userService)
        {
            _fieldsOfLawService = fieldsOfLawService;
            _userAreaService = userAreaService;
            _userService = userService;
        }


        // GET: Admin/FieldsOfLaw
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.FieldsOfLaw = _fieldsOfLawService.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ExceptionHandler]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FieldsOfLaw model)
        {
            _fieldsOfLawService.Add(model);
            return RedirectToAction("Index", "FieldsOfLaw");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fieldsOfLaw = _fieldsOfLawService.Find(x => x.Id == id);

            if (fieldsOfLaw == null)
            {
                return HttpNotFound();
            }

            return View(fieldsOfLaw);
        }


        [HttpPost]
        [ExceptionHandler]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FieldsOfLaw model)
        {
            var result = _fieldsOfLawService.Update(model);

            return RedirectToAction("Details", "FieldsOfLaw", new { @id = model.Id });
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fieldsOfLaw = _fieldsOfLawService.Find(x => x.Id == id);

            if (fieldsOfLaw == null)
            {
                return HttpNotFound();
            }
            DetailsViewModel model = new DetailsViewModel();
            model.FieldsOfLaw = fieldsOfLaw;
            var userIds = _userAreaService.List(x => x.FieldsOfLawId == id).Select(u => u.AppUserId).ToList();
            model.Users = _userService.List(x=>userIds.Contains(x.Id));

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fieldsOfLaw = _fieldsOfLawService.Find(x => x.Id == id);

            if (fieldsOfLaw == null)
            {
                return HttpNotFound();
            }


            return View(fieldsOfLaw);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                var fieldsOfLaw = _fieldsOfLawService.Find(x => x.Id == id);
                _fieldsOfLawService.Delete(fieldsOfLaw);
                return RedirectToAction("Index", "FieldsOfLaw");

            }
            catch
            {
                return RedirectToAction("Index", "FieldsOfLaw");
            }

        }
    }
}