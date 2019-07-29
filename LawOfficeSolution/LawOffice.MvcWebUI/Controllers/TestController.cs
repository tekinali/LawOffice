using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.Business.Abstract;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Controllers
{
    public class TestController : Controller
    {
        private ICategoryService _categoryService;
        private IBlogService _blogService;
        private IUserService _userService;

        public TestController(ICategoryService categoryService, IBlogService blogService,IUserService userService)
        {
            _categoryService = categoryService;
            _blogService = blogService;
            _userService = userService;
        }

        // GET: Test
        public ActionResult Index()
        {
            AppUser t = new AppUser()
            {
                UserName="BBBBaa",
                Password="123456",
                Email="aaa@aaac.com",
                FirstName="ilk ad",
                LastName="Last"                
            };

            var data = _userService.Add(t);
       

            return View();
        }
    }
}