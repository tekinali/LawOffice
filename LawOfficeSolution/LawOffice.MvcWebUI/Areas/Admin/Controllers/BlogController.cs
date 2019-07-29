using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.Business.Abstract;
using LawOffice.MvcWebUI.Areas.Admin.ViewModels.Blog;
using LawOffice.MvcWebUI.Filters;
using LawOffice.Entities.Concrete;
using System.Net;

namespace LawOffice.MvcWebUI.Areas.Admin.Controllers
{
    [Exc]
    [Auth]
    [AuthAdmin]
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private IUserService _userService;
        private IBlogCategoryService _blogCategoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService,
            IUserService userService, IBlogCategoryService blogCategoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
            _blogCategoryService = blogCategoryService;
        }

        // GET: Admin/Blog
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            model.Blogs = _blogService.GetAllWithDetails();

            return View(model);
        }

        public ActionResult Create()
        {
            var categories = _categoryService.GetAll().OrderBy(x => x.Name).ToList();
            var users = _userService.GetAll().OrderBy(x => x.UserName).ToList();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.UserId = new SelectList(users, "Id", "UserName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Create(CreateViewModel model)
        {
            try
            {    
                var data = _blogService.Add(new Blog()
                {
                    Text = model.Text,
                    Summary = model.Summary,
                    Name = model.Name,
                    CreatedOn = DateTime.Now,
                    AppUserId = model.UserId
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

            var blog = _blogService.WithDetails(x => x.Id == id);

            if (blog == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel model = new DetailsViewModel();
            model.Blog = blog;
            model.User = blog.AppUser;
            model.Categories = blog.BlogCategories.Select(c => c.Category).OrderBy(x=>x.Name).ToList();


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
            var users = _userService.GetAll().OrderBy(x => x.UserName).ToList();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.UserId = new SelectList(users, "Id", "UserName");

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
                    blog.AppUserId = model.Blog.AppUserId;

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

            var blog = _blogService.WithDetails(x => x.Id == id);

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
                var blog = _blogService.Find(x => x.Id == id);
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
            if(blogCategoryId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var blogCategory = _blogCategoryService.Find(x => x.Id == blogCategoryId);
   
            if (blogCategory==null)
            {
                return HttpNotFound();
            }

            var blogId = blogCategory.BlogId;




            try
            {         
                _blogCategoryService.Delete(blogCategory);
                return RedirectToAction("Edit", "Blog",new { id= blogId });
            }
            catch
            {
                return RedirectToAction("Edit", "Blog", new { id = blogId });
            }
      
        }

    }
}