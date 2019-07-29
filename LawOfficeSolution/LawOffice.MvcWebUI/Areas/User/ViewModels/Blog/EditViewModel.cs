using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.User.ViewModels.Blog
{
    public class EditViewModel
    {
        public Entities.Concrete.Blog Blog { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
    }
}