using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.User.ViewModels.Blog
{
    public class IndexViewModel
    {
        public List<Entities.Concrete.Blog> Blogs { get; set; }
    }
}