using LawOffice.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.MvcWebUI.Areas.User.ViewModels.Blog;
using LawOffice.Core.CrossCuttingConcerns.Security;
using System.Net;
using LawOffice.Entities.Concrete;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Areas.User.Controllers
{
    [Exc]
    [Auth]
    [AuthUser]
    public class BlogController : Controller
    {

        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private IBlogCategoryService _blogCategoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IBlogCategoryService blogCategoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _blogCategoryService = blogCategoryService;
      
        }
        
       
        public ActionResult Index()
        {
         

            IndexViewModel model = new IndexViewModel();
            Guid userId = GetUserId();
            model.Blogs = _blogService.ListWithDetails(x=>x.AppUserId== userId);

            return View(model);
        }

        public ActionResult Create()
        {
            var categories = _categoryService.GetAll().OrderBy(x => x.Name).ToList();
      

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
         

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            try
            {

                Guid userId = GetUserId();

                var data = _blogService.Add(new Blog()
                {
                    Text = model.Text,
                    Summary = model.Summary,
                    Name = model.Name,
                    CreatedOn = DateTime.Now,
                    AppUserId = userId
                }, model.CategoryId);

                return RedirectToAction("Index", "Blog");
            }
            catch
            {
                return RedirectToAction("Create", "Blog");
            }
            
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Guid userId = GetUserId();
            var blog = _blogService.WithDetails(x => x.Id == id && x.AppUserId == userId);

            if (blog == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel model = new DetailsViewModel();
            model.Blog = blog;           
            model.Categories = blog.BlogCategories.Select(c => c.Category).OrderBy(x => x.Name).ToList();


            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var blog = _blogService.WithDetails(x => x.Id == id);

            if (blog == null)
            {
                return HttpNotFound();
            }

            var categories = _categoryService.GetAll().OrderBy(x => x.Name).ToList();
          

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");          

            EditViewModel model = new EditViewModel();
            model.Blog = blog;
            //model.BlogCategories = blog.BlogCategories.OrderBy(x=>x.Category.Name).ToList();          
            model.BlogCategories = _blogCategoryService.ListWithDetails(x => x.BlogId == id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Edit(EditViewModel model)
        {

            try
            {
                ModelState.Remove("BlogCategories");
                ModelState.Remove("CreatedOn");
                ModelState.Remove("AppUserId");
                if (ModelState.IsValid)
                {
                    var blog = _blogService.WithDetails(x => x.Id == model.Blog.Id);
                    blog.Name = model.Blog.Name;
                    blog.Summary = model.Blog.Summary;
                    blog.Text = model.Blog.Text;                  

                    var result = _blogService.Update(blog);
                    return RedirectToAction("Details", "Blog", new { id = model.Blog.Id });
                }
                return View(model);
            }
            catch
            {
                return RedirectToAction("Edit", "Blog", new { id = model.Blog.Id });
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ExceptionHandler]
        public ActionResult AddCategoryToBlog(int? blogId, int? categoryId)
        {

            if (blogId == null || categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var blogCategory = _blogCategoryService.Add(new BlogCategory()
                {
                    BlogId = (int)blogId,
                    CategoryId = (int)categoryId
                });

                return RedirectToAction("Edit", "Blog", new { id = blogId });
            }
            catch
            {
                return RedirectToAction("Edit", "Blog", new { id = blogId });
            }

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Guid userId = GetUserId();
            var blog = _blogService.WithDetails(x => x.Id == id && x.AppUserId ==userId);

            if (blog == null)
            {
                return HttpNotFound();
            }


            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Guid userId = GetUserId();
                var blog = _blogService.WithDetails(x => x.Id == id && x.AppUserId == userId);

                _blogService.Delete(blog);
                return RedirectToAction("Index", "Blog");
            }
            catch
            {
                return RedirectToAction("Index", "Blog");
            }


        }


        public ActionResult RemoveCategoryFromBlog(int? blogCategoryId)
        {
            if (blogCategoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var blogCategory = _blogCategoryService.Find(x => x.Id == blogCategoryId);

            if (blogCategory == null)
            {
                return HttpNotFound();
            }

            var blogId = blogCategory.BlogId;




            try
            {
                _blogCategoryService.Delete(blogCategory);
                return RedirectToAction("Edit", "Blog", new { id = blogId });
            }
            catch
            {
                return RedirectToAction("Edit", "Blog", new { id = blogId });
            }

        }




        private Guid GetUserId()
        {
            var myIdentity = (Identity)System.Web.HttpContext.Current.User.Identity;
            var userId = myIdentity.UserId;

            return userId;
        }


    }
}