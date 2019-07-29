using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.Entities.Concrete;
using LawOffice.Business.Abstract;
using LawOffice.MvcWebUI.Areas.Admin.ViewModels.Category;
using LawOffice.MvcWebUI.Filters;
using System.Net;

namespace LawOffice.MvcWebUI.Areas.Admin.Controllers
{
    [Exc]
    [Auth]
    [AuthAdmin]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        private IBlogCategoryService _blogCategoryService;
        private IBlogService _blogService;


        public CategoryController(ICategoryService categoryService, IBlogCategoryService blogCategoryService, IBlogService blogService)
        {
            _categoryService = categoryService;
            _blogCategoryService = blogCategoryService;
            _blogService = blogService;
        }


        // GET: Admin/Category
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Categories = _categoryService.GetAll().OrderBy(x=>x.Name).ToList();

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ExceptionHandler]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            _categoryService.Add(model);
            return RedirectToAction("Index", "Category");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoryService.Find(x => x.Id == id);

            if (category==null)
            {
                return HttpNotFound();
            }

            return View(category);
        }


        [HttpPost]
        [ExceptionHandler]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            var result = _categoryService.Update(model);

            return RedirectToAction("Details", "Category", new { @id = model.Id });
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoryService.Find(x => x.Id == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel model = new DetailsViewModel();
            model.Category = category;
            var blogIds= _blogCategoryService.ListWithDetails(x => x.CategoryId == category.Id).Select(u => u.BlogId).ToList();
            model.Blogs = _blogService.ListWithDetails(x=> blogIds.Contains(x.Id));

            return View(model);
        }

        public ActionResult Delete(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoryService.Find(x => x.Id == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                var category = _categoryService.Find(x => x.Id == id);
                _categoryService.Delete(category);
                return RedirectToAction("Index", "Category");

            }
            catch
            {
                return RedirectToAction("Index", "Category");
            }
           
        }

    }
}