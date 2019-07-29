using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using LawOffice.Entities.Concrete;
using LawOffice.Business.Abstract;
using System.Net;
using LawOffice.MvcWebUI.ViewModels.Blog;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Controllers
{
    [Exc]
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private IBlogCategoryService _blogCategoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService,IBlogCategoryService blogCategoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _blogCategoryService = blogCategoryService;
        }


        // GET: Blog
        public ActionResult Index(int Page = 1, int? id = -1)
        {
            if (id == null || id == -1)
            {
                ViewBag.CategoryId = null;

                var blogs = _blogService.GetAll().ToPagedList(Page,5);
                return View(blogs);
            }
            else
            {
                var category = _categoryService.Find(x => x.Id == id);

                if (category == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ViewBag.CategoryId = id;

                var categoryBlogs = _blogCategoryService.ListWithDetails(x => x.CategoryId == id).Select(u => u.Blog).ToList();
                var blogs = categoryBlogs.ToPagedList(Page, 5);
              
                return View(blogs);
            }
                       
           
        }

        public ActionResult BlogPost(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogPostViewModel model = new BlogPostViewModel();
            model.Blog = _blogService.WithDetails(x => x.Id == id);

            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult CategoryList()
        {
            var categoryList = _categoryService.GetAll();

            return PartialView("_PartialCategoryList", categoryList);
        }

        [ChildActionOnly]
        public PartialViewResult PartialSearch()
        {

            return PartialView("_PartialSearch");
        }



    }
}